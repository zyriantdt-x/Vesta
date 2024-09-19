using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Streams;
using Vesta.Server.Util;

namespace Vesta.Server.Codec;
internal class MessageDecoder : ByteToMessageDecoder {
    /*private readonly ILogger<MessageDecoder> logger;

    public MessageDecoder( ILogger<MessageDecoder> logger ) {
        this.logger = logger;
    }*/

    protected override void Decode( IChannelHandlerContext context, IByteBuffer input, List<object> output ) {
        if( input.ReadableBytes < 5 )
            return;

        input.MarkReaderIndex();
        int length = Base64Encoding.Decode( [ input.ReadByte(), input.ReadByte(), input.ReadByte() ] );

        if( input.ReadableBytes < length ) {
            input.ResetReaderIndex();
            return;
        }

        if( length < 0 )
            return;

        NRequest request = new( input.ReadBytes( length ) );

        //this.logger.LogInformation( $"RCVD: {request.Header} ({request.HeaderId}) / {request.BodyString}" );

        output.Add( request );
    }
}
