using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Packets.Outgoing.Flats;
using Vesta.Server.Sessions;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Incoming.Flats;
internal class GetRoomInterestPacketHandler : IPacketHandler {
    public short Header => IncomingPackets.GET_INTEREST;

    public Task Handle( ISession session, IRequest request ) 
        => session.Send( new RoomInterestPacketComposer() );
}
