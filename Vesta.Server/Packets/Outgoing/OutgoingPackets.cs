using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vesta.Server.Packets.Outgoing;
internal static class OutgoingPackets {
    // handshake
    public const short HELLO = 0;
    public const short CRYPTO_PARAMETERS = 277;
    public const short SESSION_PARAMETERS = 257;
    public const short AVAILABLE_SETS = 8;
    public const short LOGIN = 3;
    public const short RIGHTS = 2;

    // alerts
    public const short ALERT = 139;
    public const short HOTEL_LOGOUT = 287;

    // players
    public const short USER_OBJECT = 5;

    // purse
    public const short CREDIT_BALANCE = 6;

    // navi
    public const short NAV_NODE_INFO = 220;

    // flats
    public const short FLAT_INFO = 54;
    public const short ROOM_INTEREST = 258;
    public const short OPEN_CONNECTION = 19;
    public const short FLAT_LET_IN = 41;
}
