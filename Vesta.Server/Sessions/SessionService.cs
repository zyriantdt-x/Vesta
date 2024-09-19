using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vesta.Server.Sessions;
internal class SessionService : ISessionService {
    private readonly List<ISession> sessions;

    public SessionService() {
        this.sessions = new();
    }

    public ISession CreateSession( IChannel channel ) {
        Session session = new() {
            Uuid = Guid.NewGuid().ToString(),   // not sure why I want this, but I do...
            Channel = channel
        };

        this.RegisterSession( session );

        return session;
    }

    public void RegisterSession( ISession session )
        => this.sessions.Add( session );

    public void DeregisterSession( ISession session ) 
        => this.sessions.Remove( session );

    public ISession? GetSessionByUuid( string uuid )
        => this.sessions.Where( session => session.Uuid == uuid ).FirstOrDefault();

    public ISession? GetSessionByChannel( IChannel channel )
        => this.sessions.Where( session => session.Channel == channel ).FirstOrDefault();

    public ISession? GetSessionByPlayerId( int player_id )
        => this.sessions.Where( session => session.PlayerId == player_id ).FirstOrDefault();
}
