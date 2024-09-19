using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Outgoing.Alerts;
internal class AlertPacketComposer : PacketComposerBase {
    public override short Header => OutgoingPackets.ALERT;

    public required string Message { get; set; }

    public override void Compose( IResponse response ) {
        response.WriteString( this.Message );
    }
}
