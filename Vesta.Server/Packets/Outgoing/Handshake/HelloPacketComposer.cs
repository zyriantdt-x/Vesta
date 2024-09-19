using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Outgoing.Handshake;
internal class HelloPacketComposer : PacketComposerBase {
    public override short Header => OutgoingPackets.HELLO;

    public override void Compose( IResponse response ) {}
}
