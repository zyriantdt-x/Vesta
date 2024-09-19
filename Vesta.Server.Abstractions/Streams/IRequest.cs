using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vesta.Server.Streams;
public interface IRequest {
    int ReadInt();
    int ReadBase64();
    bool ReadBoolean();
    string ReadString();
    byte[] ReadBytes( int len );
    byte[] RemainingBytes();
    string? Contents { get; }
    string BodyString { get; }
    int HeaderId { get; }
    string Header { get; }
}
