using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Streams;
using Vesta.Shared.Http.Responses.Navigator;
using Vesta.Shared.Http.Responses.Rooms;

namespace Vesta.Server.Packets.Outgoing.Navigator;
internal class NavNodeInfoPacketComposer : PacketComposerBase {
    public override short Header => OutgoingPackets.NAV_NODE_INFO;

    public required NavigatorCategoryHttpResponse ParentCategory { get; set; }
    public required ICollection<GetFlatHttpResponse> Flats { get; set; }
    public required bool HideFull { get; set; }
    public required ICollection<NavigatorCategoryHttpResponse> Subcategories { get; set; }

    public override void Compose( IResponse response ) {
        response.WriteBool( this.HideFull );
        response.WriteInt( this.ParentCategory.Id );
        response.WriteInt( this.ParentCategory.IsPublicSpace ? 0 : 2 );
        response.WriteString( this.ParentCategory.Name );
        response.WriteInt( 100 ); // current visitors
        response.WriteInt( 100 ); // max visitors
        response.WriteInt( this.ParentCategory.ParentId );

        if( !this.ParentCategory.IsPublicSpace ) {
            response.WriteInt( this.Flats.Count );
        }

        foreach(GetFlatHttpResponse flat in this.Flats) {
            if( flat.OwnerId == 0 ) { // public room
                int idx = 0;
                string desc = flat.Description;

                if( desc.Contains( "/" ) ) {
                    string[] data = desc.Split( '/' );
                    desc = data[ 0 ];
                    idx = Convert.ToInt32( data[ 1 ] );
                }

                response.WriteInt( flat.Id + 1000 ); // public room port
                response.WriteInt( 1 );
                response.WriteString( flat.Name );
                response.WriteInt( flat.VisitorsNow );
                response.WriteInt( flat.VisitorsMax );
                response.WriteInt( flat.Category );
                response.WriteString( desc );
                response.WriteInt( flat.Id );
                response.WriteInt( idx );
                response.WriteString( flat.Ccts ?? "" );
                response.WriteInt( 0 );
                response.WriteInt( 1 );
            } else {
                response.WriteInt( flat.Id );
                response.WriteString( flat.Name );

                // todo: name show check
                response.WriteString( "-" );

                response.WriteString( flat.AccessType switch {
                    1 => "closed",
                    2 => "password",
                    _ => "open"
                } );
                response.WriteInt( flat.VisitorsNow );
                response.WriteInt( flat.VisitorsMax );
                response.WriteString( flat.Description );
            }
        }

        foreach( NavigatorCategoryHttpResponse subcategory in this.Subcategories ) {
            response.WriteInt( subcategory.Id );
            response.WriteInt( 0 );
            response.WriteString( subcategory.Name );
            response.WriteInt( 100 ); // current visitors
            response.WriteInt( 100 ); // max visitors
            response.WriteInt( subcategory.ParentId );
        }
    }
}
