using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Streams;

namespace Vesta.Server.Packets.Outgoing.Handshake;
internal class SessionParametersPacketComposer : PacketComposerBase {
    public override short Header => OutgoingPackets.SESSION_PARAMETERS;

    public override void Compose( IResponse response ) {
        Dictionary<SessionParameters, string> parameters = new() {
            { SessionParameters.VOUCHER_ENABLED, "1" }, // todo: load from db
            { SessionParameters.REGISTER_REQUIRE_PARENT_EMAIL, "0" },
            { SessionParameters.REGISTER_SEND_PARENT_EMAIL, "0" },
            { SessionParameters.ALLOW_DIRECT_MAIL, "0" },
            { SessionParameters.DATE_FORMAT, "dd-MM-yyyy" },
            { SessionParameters.PARTNER_INTEGRATION_ENABLED, "0" },
            { SessionParameters.ALLOW_PROFILE_EDITING, "1" }, // todo: load from db
            { SessionParameters.TRACKING_HEADER, "" },
            { SessionParameters.TUTORIAL_ENABLED, "0" },
        };

        response.WriteInt( parameters.Count );

        foreach( KeyValuePair<SessionParameters, string> parameter in parameters ) {
            SessionParameters key = parameter.Key;
            string value = parameter.Value;

            response.WriteInt( ( int )key );

            if( !String.IsNullOrWhiteSpace( value ) && Int32.TryParse( value, out int value_as_int ) )
                response.WriteInt( value_as_int );
            else
                response.WriteString( value );
        }
    }
}

internal enum SessionParameters {
    VOUCHER_ENABLED = 1,
    REGISTER_REQUIRE_PARENT_EMAIL = 2,
    REGISTER_SEND_PARENT_EMAIL = 3,
    ALLOW_DIRECT_MAIL = 4,
    DATE_FORMAT = 5,
    PARTNER_INTEGRATION_ENABLED = 6,
    ALLOW_PROFILE_EDITING = 7,
    TRACKING_HEADER = 8,
    TUTORIAL_ENABLED = 9
}