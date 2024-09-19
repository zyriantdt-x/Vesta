using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Codec;
using Vesta.Server.Packets.Outgoing;
using Vesta.Server.Streams;

namespace Vesta.Server;
internal class ChannelInitialiser : ChannelInitializer<IChannel> {
    /*private readonly MessageToMessageEncoder<PacketComposerBase> encoder;
    private readonly ByteToMessageDecoder decoder;*/
    private readonly ChannelHandlerAdapter channel_handler;

    public ChannelInitialiser( /*MessageToMessageEncoder<PacketComposerBase> encoder,
                               ByteToMessageDecoder decoder,*/
                               ChannelHandlerAdapter channel_handler ) {
        /*this.encoder = encoder;
        this.decoder = decoder;*/
        this.channel_handler = channel_handler;
    }

    protected override void InitChannel( IChannel channel ) {
        IChannelPipeline pipeline = channel.Pipeline;
        pipeline.AddLast( "gameEncoder", new MessageEncoder() );
        pipeline.AddLast( "gameDecoder",  new MessageDecoder() );
        pipeline.AddLast( "clientHandler", this.channel_handler );
    }
}
