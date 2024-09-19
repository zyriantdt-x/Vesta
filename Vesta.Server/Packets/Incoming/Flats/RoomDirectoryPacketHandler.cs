using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Packets.Outgoing.Flats;
using Vesta.Server.Sessions;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Incoming.Flats;
internal class RoomDirectoryPacketHandler : IPacketHandler {
    public short Header => IncomingPackets.ROOM_DIRECTORY;

    public async Task Handle( ISession session, IRequest request ) {
        bool is_public = request.Contents![ 0 ] == 'A';

        if(!is_public) {
            _ = session.Send( new OpenConnectionPacketComposer() );
            return;
        }

        _ = request.ReadBytes( 1 );

        int room_id = request.ReadInt();

        // handle public room
    }
}
