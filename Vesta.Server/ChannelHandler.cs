using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Packets.Incoming;
using Vesta.Server.Packets.Outgoing.Handshake;
using Vesta.Server.Sessions;
using Vesta.Server.Streams;

namespace Vesta.Server;
internal class ChannelHandler : ChannelHandlerAdapter {
    public static AttributeKey<ISession> SESSION_ATTRIBUTE = AttributeKey<ISession>.NewInstance( "SESSION" );

    private readonly ILogger<ChannelHandler> logger;
    private readonly ISessionService session_service;
    private readonly IPacketProcessor packet_processor;

    public override bool IsSharable => true;

    public ChannelHandler( ILogger<ChannelHandler> logger,
                           ISessionService session_service,
                           IPacketProcessor packet_processor ) {
        this.logger = logger;
        this.session_service = session_service;
        this.packet_processor = packet_processor;
    }

    public override void ChannelActive( IChannelHandlerContext ctx ) {
        base.ChannelActive( ctx );

        ISession session = this.session_service.CreateSession( ctx.Channel );
        ctx.Channel.GetAttribute( SESSION_ATTRIBUTE ).SetIfAbsent( session );

        this.logger.LogInformation( $"New connection from {ctx.Channel.RemoteAddress}" );

        session.Send( new HelloPacketComposer() );
    }

    public override void ChannelInactive( IChannelHandlerContext ctx ) {
        base.ChannelInactive( ctx );

        ISession? session = ctx.Channel.GetAttribute( SESSION_ATTRIBUTE ).Get();
        if( session == null ) {
            this.logger.LogError( $"Session-less channel closed ({ctx.Channel.RemoteAddress})" );
            return;
        }

        if(session.PlayerId != null) {
            // do some stuff
        }

        this.session_service.DeregisterSession( session );

        this.logger.LogInformation( $"Connection from {ctx.Channel.RemoteAddress} closed" );
    }

    public override void ChannelRead( IChannelHandlerContext ctx, object msg ) {
        ISession? session = ctx.Channel.GetAttribute( SESSION_ATTRIBUTE ).Get();
        if( session == null ) {
            this.logger.LogError( $"Message read from session-less channel ({ctx.Channel.RemoteAddress})" );
            return;
        }

        if( msg is not NRequest ) {
            this.logger.LogError( $"Message read was not NRequest ({ctx.Channel.RemoteAddress})" );
            return;
        }

        NRequest request = ( NRequest )msg;

        this.logger.LogInformation( $"RCVD: {request.Header} ({request.HeaderId}) / {request.BodyString}" );

        this.packet_processor.ProcessPacket(session, request );

        base.ChannelRead( ctx, msg );
    }

    public override void ChannelReadComplete( IChannelHandlerContext context ) 
        => context.Flush();
}
