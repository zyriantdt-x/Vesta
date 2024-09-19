using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Outgoing.Handshake;
internal class CryptoParametersPacketComposer : PacketComposerBase {
    public override short Header => OutgoingPackets.CRYPTO_PARAMETERS;

    public override void Compose( IResponse response ) {
        response.WriteInt( 0 );
    }
}
