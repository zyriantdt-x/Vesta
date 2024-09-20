using DotNetty.Buffers;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Groups;
using DotNetty.Transport.Channels.Sockets;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Vesta.Server;
internal class Application : IApplication {
    private readonly ILogger<Application> logger;
    private readonly ChannelInitializer<IChannel> channel_initialiser;

    private readonly IEventLoopGroup master_group;
    private readonly IEventLoopGroup slave_group;

    private readonly ServerBootstrap svr_boostrap;

    public Application( ILogger<Application> logger,
                        ChannelInitializer<IChannel> channel_initialiser ) {
        this.logger = logger;
        this.channel_initialiser = channel_initialiser;

        this.master_group = new MultithreadEventLoopGroup( 10 );
        this.slave_group = new MultithreadEventLoopGroup( 10 ); // might change this?

        this.svr_boostrap = new ServerBootstrap();
        this.svr_boostrap
            .Group( this.master_group, this.slave_group )
            .Channel<TcpServerSocketChannel>()
            .ChildOption( ChannelOption.TcpNodelay, true )
            .ChildOption( ChannelOption.SoKeepalive, true )
            .ChildOption( ChannelOption.SoReuseaddr, true )
            .ChildOption( ChannelOption.SoRcvbuf, 1024 )
            .ChildOption( ChannelOption.RcvbufAllocator, new FixedRecvByteBufAllocator( 1024 ) )
            .ChildOption( ChannelOption.Allocator, UnpooledByteBufferAllocator.Default )
            .ChildHandler( this.channel_initialiser );
    }

    public async Task Run() {
        int port = Convert.ToInt32( Environment.GetEnvironmentVariable( "VESTA_PORT" ) ?? "12321" );

        await this.svr_boostrap.BindAsync( new IPEndPoint( IPAddress.Parse( "0.0.0.0" ), port ) );

        this.logger.LogCritical( $"Listening on port {port}." );
    }
}
