using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Streams;
using Vesta.Shared.Http.Responses.Player;
using Vesta.Shared.Http.Responses.Rooms;

namespace Vesta.Server.Packets.Outgoing.Flats;
internal class FlatInfoPacketComposer : PacketComposerBase {
    public override short Header => OutgoingPackets.FLAT_INFO;

    public required UserObjectHttpResponse Owner { get; set; }
    public required GetFlatHttpResponse Flat { get; set; }
    public required RoomModelHttpResponse Model { get; set; }

    public override void Compose( IResponse response ) {
        response.WriteBool( this.Flat.SuperUsers );
        response.WriteInt( this.Flat.AccessType );
        response.WriteInt( this.Flat.Id );

        // todo: allow owner hiding
        response.WriteString( this.Owner.Username );

        response.WriteString( this.Model.Name );
        response.WriteString( this.Flat.Name );
        response.WriteString( this.Flat.Description );
        response.WriteBool( true ); // show owner name;
        response.WriteBool( true ); // allow trading
        response.WriteBool( false ); // ?
        response.WriteInt( this.Flat.VisitorsNow );
        response.WriteInt( this.Flat.VisitorsMax );
    }
}
