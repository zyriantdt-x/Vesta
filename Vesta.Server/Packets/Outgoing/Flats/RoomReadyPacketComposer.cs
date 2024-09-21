using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Outgoing.Flats;
internal class RoomReadyPacketComposer : PacketComposerBase {
    public override short Header => OutgoingPackets.ROOM_READY;

    public required int RoomId { get; set; }
    public required string Model { get; set; }

    public override void Compose( IResponse response ) {
        response.WriteString( this.Model );
        response.Write( " " );
        response.WriteInt( this.RoomId );
    }
}
