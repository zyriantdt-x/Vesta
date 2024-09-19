using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Packets.Outgoing.Handshake;
using Vesta.Server.Sessions;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Incoming.Handshake;
internal class GenerateKeyPacketHandler : IPacketHandler {
    public short Header => IncomingPackets.GENERATE_KEY;

    public async Task Handle( ISession session, IRequest request ) {
        if( session.PlayerId != null )
            return;

        _ = session.Send( new SessionParametersPacketComposer() );
        _ = session.Send( new AvailableSetsPacketComposer() );
    }
}
