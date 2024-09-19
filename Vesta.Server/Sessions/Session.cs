using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Packets.Outgoing;

namespace Vesta.Server.Sessions;
internal class Session : ISession {
    public required string Uuid { get; init; }
    public required IChannel Channel { get; init; }

    public int? PlayerId { get; set; }

    public Task Send( PacketComposerBase composer ) 
        => this.Channel.WriteAndFlushAsync( composer );

    public Task SendQueued( PacketComposerBase composer ) 
        => this.Channel.WriteAsync( composer );

    public void Flush() 
        => this.Channel.Flush();

    public Task Disconnect()
        => this.Channel.CloseAsync();
}
