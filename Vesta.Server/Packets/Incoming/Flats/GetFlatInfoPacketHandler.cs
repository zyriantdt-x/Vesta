using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Packets.Outgoing.Flats;
using Vesta.Server.ServiceApis;
using Vesta.Server.Sessions;
using Vesta.Server.Streams;
using Vesta.Shared.Http.Responses.Player;
using Vesta.Shared.Http.Responses.Rooms;

namespace Vesta.Server.Packets.Incoming.Flats;
internal class GetFlatInfoPacketHandler : IPacketHandler {
    public short Header => IncomingPackets.GET_FLAT_INFO;

    private readonly IFlatServiceApi flat_service;
    private readonly IPlayerServiceApi player_service;

    public GetFlatInfoPacketHandler( IFlatServiceApi flat_service,
                                     IPlayerServiceApi player_service ) {
        this.flat_service = flat_service;
        this.player_service = player_service;
    }

    public async Task Handle( ISession session, IRequest request ) {
        int flat_id = Convert.ToInt32( request.Contents );

        GetFlatHttpResponse? flat = await this.flat_service.GetFlatById( flat_id );
        if( flat == null )
            return;

        UserObjectHttpResponse? owner = await this.player_service.GetUserObject( flat.OwnerId );
        if( owner == null )
            return;

        RoomModelHttpResponse? model = await this.flat_service.GetRoomModelByName( flat.Model );
        if( model == null )
            return;

        _ = session.Send( new FlatInfoPacketComposer() {
            Owner = owner,
            Flat = flat,
            Model = model
        } );
    }
}
