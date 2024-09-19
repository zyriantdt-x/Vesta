using DotNetty.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Util;

namespace Vesta.Server.Streams;
internal class NResponse : IResponse {
    private short header;
    private IByteBuffer buffer;

    public NResponse( short header, IByteBuffer buffer ) {
        this.header = header;
        this.buffer = buffer;
        this.buffer.WriteBytes( Base64Encoding.Encode( header, 2 ) );
    }

    public void Write( object obj ) {
        if( obj != null )
            this.buffer.WriteBytes( Encoding.Default.GetBytes( obj.ToString()! ) );
    }

    public void WriteString( object obj ) {
        if( obj != null )
            this.buffer.WriteBytes( Encoding.Default.GetBytes( obj.ToString()! ) );

        this.buffer.WriteByte( 2 );
    }

    public void WriteInt( int number ) => this.buffer.WriteBytes( VL64Encoding.Encode( number ) );

    public void WriteKeyValue( object key, object value ) {
        this.buffer.WriteBytes( Encoding.Default.GetBytes( key.ToString()! ) );
        this.buffer.WriteBytes( Encoding.Default.GetBytes( ":" ) );
        this.buffer.WriteBytes( Encoding.Default.GetBytes( value.ToString()! ) );
        this.buffer.WriteByte( 13 );
    }

    public void WriteValue( object key, object value ) {
        this.buffer.WriteBytes( Encoding.Default.GetBytes( key.ToString()! ) );
        this.buffer.WriteBytes( Encoding.Default.GetBytes( "=" ) );
        this.buffer.WriteBytes( Encoding.Default.GetBytes( value.ToString()! ) );
        this.buffer.WriteByte( 13 );
    }

    public void WriteDelimiter( object key, object value ) {
        this.buffer.WriteBytes( Encoding.Default.GetBytes( key.ToString()! ) );
        this.buffer.WriteBytes( Encoding.Default.GetBytes( value.ToString()! ) );
    }

    public void WriteBool( bool obj ) => this.WriteInt( obj ? 1 : 0 );

    public string BodyString {
        get {
            string str = this.buffer.ToString( Encoding.Default );

            for( int i = 0 ; i < 14 ; i++ ) {
                str = str.Replace( Char.ToString( ( char )i ), "{" + i + "}" );
            }

            return str;
        }
    }

    public int Header => this.header;

    public bool IsFinalised { get; set; }
}
