using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Packets.Outgoing;

namespace Vesta.Server.Sessions;
public interface ISession {
    string Uuid { get; init; }
    IChannel Channel { get; init; }

    int? PlayerId { get; set; }

    Task Send( PacketComposerBase composer );
    Task SendQueued( PacketComposerBase composer );
    void Flush();
    Task Disconnect();
}
