using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Packets.Outgoing.Flats;
using Vesta.Server.ServiceApis;
using Vesta.Server.Sessions;
using Vesta.Server.Streams;
using Vesta.Shared.Http.Responses.Rooms;

namespace Vesta.Server.Packets.Incoming.Flats;
internal class GoToFlatPacketHandler : IPacketHandler {
    public short Header => IncomingPackets.GO_TO_FLAT;

    private readonly IFlatServiceApi flat_service;

    public GoToFlatPacketHandler( IFlatServiceApi flat_service ) {
        this.flat_service = flat_service;
    }

    public async Task Handle( ISession session, IRequest request ) {
        string? contents = request.Contents;

        if( contents == null )
            return;

        if( !Int32.TryParse( contents, out int room_id ) )
            return;

        CreateRoomSessionHttpResponse? room_session_info = await this.flat_service.CreateRoomSession( room_id, session.PlayerId ?? 0 );

        session.Send( new RoomUrlPacketComposer() );
        session.Send( new RoomReadyPacketComposer() { RoomId = room_session_info.RoomId, Model = room_session_info.Model } );
    }
}
