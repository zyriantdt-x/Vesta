using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Vesta.Server.Packets.Outgoing.Player;
using Vesta.Server.ServiceApis;
using Vesta.Server.Sessions;
using Vesta.Server.Streams;
using Vesta.Shared.Http.Responses.Player;

namespace Vesta.Server.Packets.Incoming.Player;
internal class GetInfoPacketHandler : IPacketHandler {
    public short Header => IncomingPackets.GET_INFO;

    private readonly IPlayerServiceApi player_api;

    public GetInfoPacketHandler( IPlayerServiceApi player_api ) {
        this.player_api = player_api;
    }

    public async Task Handle( ISession session, IRequest request ) {
        if( session.PlayerId == null )
            return;

        UserObjectHttpResponse? http_res = await this.player_api.GetUserObject( session.PlayerId ?? 0 /*never null*/ );
        if(http_res == null) {
            // handle failure
            return;
        }

        _ = session.Send( new UserObjectPacketComposer() {
            Id = http_res.Id,
            Username = http_res.Username,
            Figure = http_res.Figure,
            Sex = http_res.Sex,
            Mission = http_res.Mission,
            PoolFigure = http_res.PoolFigure,
            Tickets = http_res.Tickets,
            Film = http_res.Film,
            ReceiveNews = http_res.ReceiveNews
        } );
    }
}
