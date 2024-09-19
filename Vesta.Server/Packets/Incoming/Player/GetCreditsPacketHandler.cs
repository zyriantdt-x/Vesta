using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Packets.Outgoing.Player;
using Vesta.Server.ServiceApis;
using Vesta.Server.Sessions;
using Vesta.Server.Streams;
using Vesta.Shared.Http.Responses.Player;

namespace Vesta.Server.Packets.Incoming.Player;
internal class GetCreditsPacketHandler : IPacketHandler {
    public short Header => IncomingPackets.GET_CREDITS;

    private readonly IPlayerServiceApi player_api;

    public GetCreditsPacketHandler( IPlayerServiceApi player_api ) {
        this.player_api = player_api;
    }

    public async Task Handle( ISession session, IRequest request ) {
        if( session.PlayerId == null )
            return;

        UserObjectHttpResponse? http_res = await this.player_api.GetUserObject( session.PlayerId ?? 0 /*never null*/ );
        if( http_res == null ) {
            // handle failure
            return;
        }

        _ = session.Send( new CreditBalancePacketComposer() { Credits = http_res.Credits } );
    }
}
