using DotNetty.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Util;

namespace Vesta.Server.Streams;
internal class NRequest : IRequest {
    private int header_id;
    private string header;

    private IByteBuffer buffer;

    public NRequest( IByteBuffer buffer ) {
        this.buffer = buffer;

        this.header = Encoding.Default.GetString( new byte[] { buffer.ReadByte(), buffer.ReadByte() } );
        this.header_id = Base64Encoding.Decode( Encoding.Default.GetBytes( this.header ) );
    }

    public int ReadInt() {
        byte[] remaining = this.RemainingBytes();

        int length = (remaining[ 0 ] >> 3) & 7;
        int value = VL64Encoding.Decode( remaining );
        this.ReadBytes( length );

        return value;
    }

    public int ReadBase64() {
        return Base64Encoding.Decode( new byte[] {
            this.buffer.ReadByte(),
            this.buffer.ReadByte()
        } );
    }

    public bool ReadBoolean() => this.ReadInt() == 1;

    public string ReadString() {
        int length = this.ReadBase64();
        byte[] data = this.ReadBytes( length );

        return Encoding.Default.GetString( data );
    }

    public byte[] ReadBytes( int len ) {
        byte[] payload = new byte[ len ];
        this.buffer.ReadBytes( payload );

        return payload;
    }

    public byte[] RemainingBytes() {
        this.buffer.MarkReaderIndex();

        byte[] bytes = new byte[ this.buffer.ReadableBytes ];
        this.buffer.ReadBytes( bytes );

        this.buffer.ResetReaderIndex();
        return bytes;
    }

    public string? Contents {
        get {
            byte[] remaining_bytes = this.RemainingBytes();

            return remaining_bytes != null ? Encoding.Default.GetString( remaining_bytes ) : null;
        }
    }

    public string BodyString {
        get {
            string str = this.buffer.ToString( Encoding.Default );

            for( int i = 0 ; i < 14 ; i++ ) {
                str = str.Replace( Char.ToString( ( char )i ), "{" + i + "}" );
            }

            return str;
        }
    }

    public int HeaderId => this.header_id;
    public string Header => this.header;

    public void Dispose() => this.buffer.Release();
}
