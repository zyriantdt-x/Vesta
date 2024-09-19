using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Outgoing;
public abstract class PacketComposerBase {
    public abstract short Header { get; }

    public abstract void Compose( IResponse response );
}
