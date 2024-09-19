using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Sessions;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Incoming;
public interface IPacketProcessor {
    public Task ProcessPacket( ISession session, IRequest request );
    public IPacketHandler? GetPacketHandler( short header );
}
