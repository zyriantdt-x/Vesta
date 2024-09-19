using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Outgoing.Handshake;
internal class LoginPacketComposer : PacketComposerBase {
    public override short Header => OutgoingPackets.LOGIN;

    public override void Compose( IResponse response ) {
        
    }
}
