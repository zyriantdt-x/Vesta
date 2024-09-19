using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Outgoing.Player;
internal class CreditBalancePacketComposer : PacketComposerBase {
    public override short Header => OutgoingPackets.CREDIT_BALANCE;

    public required int Credits { get; init; }

    public override void Compose( IResponse response ) {
        response.WriteString( this.Credits + ".0" );
    }
}
