using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vesta.Server.Sessions;
public interface ISessionService {
    ISession CreateSession( IChannel channel );
    void RegisterSession( ISession session );
    void DeregisterSession( ISession session );
    ISession? GetSessionByUuid( string uuid );
    ISession? GetSessionByChannel( IChannel channel );
    ISession? GetSessionByPlayerId( int playerId );
}
