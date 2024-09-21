using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Sessions;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Incoming.Flats;
internal class GoToFlatPacketHandler : IPacketHandler {
    public short Header => IncomingPackets.GO_TO_FLAT;

    public async Task Handle( ISession session, IRequest request ) {
    
    }
}
