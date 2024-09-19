using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vesta.Server.Streams;
public interface IResponse {
    void Write( object obj );
    void WriteString( object obj );
    void WriteInt( int number );
    void WriteKeyValue( object key, object value );
    void WriteValue( object key, object value );
    void WriteDelimiter( object key, object value );
    void WriteBool( bool obj );

    string BodyString { get; }
    int Header { get; }
    bool IsFinalised { get; set; }
}
