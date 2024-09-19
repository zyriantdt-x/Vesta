using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Packets.Outgoing;
using Vesta.Server.Streams;
using Vesta.Server.Util;

namespace Vesta.Server.Codec;
internal class MessageEncoder : MessageToMessageEncoder<PacketComposerBase> {
    /*private ILogger<MessageEncoder> logger;

    public MessageEncoder( ILogger<MessageEncoder> logger ) {
        this.logger = logger;
    }*/

    protected override void Encode( IChannelHandlerContext context, PacketComposerBase message, List<object> output ) {
        IByteBuffer buffer = Unpooled.Buffer();

        NResponse response = new( message.Header, buffer );
        message.Compose( response );

        if( !response.IsFinalised ) {
            buffer.WriteByte( 1 );
            response.IsFinalised = true;
        }

        //this.logger.LogInformation( $"SENT: {Encoding.Default.GetString( Base64Encoding.Encode( response.Header, 2 ) )} ({response.Header}) / {response.BodyString}" );

        output.Add( buffer );
    }
}
