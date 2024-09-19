using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Outgoing.Flats;
internal class OpenConnectionPacketComposer : PacketComposerBase {
    public override short Header => OutgoingPackets.OPEN_CONNECTION;

    public override void Compose( IResponse response ) {
    }
}
