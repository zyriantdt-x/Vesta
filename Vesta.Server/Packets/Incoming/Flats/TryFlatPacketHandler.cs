using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Packets.Outgoing.Flats;
using Vesta.Server.Sessions;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Incoming.Flats;
internal class TryFlatPacketHandler : IPacketHandler {
    public short Header => IncomingPackets.TRY_FLAT;

    public async Task Handle( ISession session, IRequest request ) {
        int? room_id;
        string? password;

        string? packet_contents = request.Contents;

        if( packet_contents == null )
            return;

        if( packet_contents.Length == 0 )
            return;

        if(packet_contents.Contains("/")) {
            string[] split_packet_contents = packet_contents.Split('/');

            try { // this is so fucking ugly
                room_id = Convert.ToInt32( split_packet_contents[ 0 ] );
            } catch (FormatException) {
                return;
            }

            password = split_packet_contents[ 1 ];
        } else {
            try { // and we have to duplicate it cba
                room_id = Convert.ToInt32( packet_contents );
            } catch( FormatException ) {
                return;
            }
        }

        // room id should now no longer be null, and password shouldn't be null if we need it.

        // todo: doorbell / password

        _ = session.Send( new FlatLetInPacketComposer() );
    }
}
