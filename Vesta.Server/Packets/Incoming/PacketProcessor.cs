using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Sessions;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Incoming;
internal class PacketProcessor : IPacketProcessor {
    private readonly ILogger<PacketProcessor> logger;
    private readonly List<IPacketHandler> handlers;

    public PacketProcessor( ILogger<PacketProcessor> logger,
                            IEnumerable<IPacketHandler> handlers ) {
        this.logger = logger;
        this.handlers = handlers.ToList();
    }

    public async Task ProcessPacket( ISession session, IRequest request ) {
        IPacketHandler? handler = this.GetPacketHandler( (short)request.HeaderId );
        if(handler == null) {
            this.logger.LogError( $"Unable to find handler for header {request.HeaderId} / {request.Header}" );
            return;
        }

        _ = handler.Handle( session, request );
    }

    public IPacketHandler? GetPacketHandler( short header ) 
        => this.handlers.Where( handler => handler.Header == header ).FirstOrDefault();
}
