using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Vesta.Server.Packets.Outgoing.Alerts;
using Vesta.Server.Packets.Outgoing.Handshake;
using Vesta.Server.ServiceApis;
using Vesta.Server.Sessions;
using Vesta.Server.Streams;
using Vesta.Shared.Http.Requests;
using Vesta.Shared.Http.Responses.Player;

namespace Vesta.Server.Packets.Incoming.Handshake;
internal class TryLoginPacketHandler : IPacketHandler {
    public short Header => IncomingPackets.TRY_LOGIN;

    private readonly IPlayerServiceApi player_api;

    public TryLoginPacketHandler( IPlayerServiceApi player_api ) {
        this.player_api = player_api;
    }

    public async Task Handle( ISession session, IRequest request ) {
        if( session.PlayerId != null )
            return;

        string username = Regex.Replace( request.ReadString(), @"[^a-zA-Z0-9\-]", "" );
        string password = Regex.Replace( request.ReadString(), @"[^a-zA-Z0-9\-]", "" );

        LoginHttpRequest http_req = new() { Username = username, Password = password };

        LoginHttpResponse? http_res = await this.player_api.Login( http_req );
        if( http_res == null ) {
            _ = session.Send( new AlertPacketComposer() { Message = "Username or password incorrect." } );
            return;
        }

        // authenticate session
        session.PlayerId = http_res.PlayerId;

        _ = session.Send( new LoginPacketComposer() );

        return;
    }
}
