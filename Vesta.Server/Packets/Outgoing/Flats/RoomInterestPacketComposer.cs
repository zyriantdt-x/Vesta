using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Outgoing.Flats;
internal class RoomInterestPacketComposer : PacketComposerBase {
    public override short Header => OutgoingPackets.ROOM_INTEREST;

    public override void Compose( IResponse response ) {
        response.WriteInt( 0 );
    }
}
