using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Outgoing.Player;
internal class UserObjectPacketComposer : PacketComposerBase {
    public override short Header => OutgoingPackets.USER_OBJECT;

    public required int Id { get; init; }
    public required string Username { get; init; }
    public required string Figure { get; init; }
    public required char Sex { get; init; } // 1 male 0 female
    public required string Mission { get; init; }
    public required int Tickets { get; init; }
    public required string PoolFigure { get; init; }
    public required int Film { get; init; }
    public required bool ReceiveNews { get; init; }

    public override void Compose( IResponse response ) {
        response.WriteString( this.Id.ToString()! );
        response.WriteString( this.Username );
        response.WriteString( this.Figure );
        response.WriteString( this.Sex );
        response.WriteString( this.Mission );
        response.WriteInt( this.Tickets );
        response.WriteString( this.PoolFigure );
        response.WriteInt( this.Film );
        response.WriteBool( this.ReceiveNews );
    }
}
