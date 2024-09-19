using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Outgoing.Flats;
internal class FlatLetInPacketComposer : PacketComposerBase {
    public override short Header => OutgoingPackets.FLAT_LET_IN;

    public override void Compose( IResponse response ) {

    }
}
