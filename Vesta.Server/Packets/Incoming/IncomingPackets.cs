using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vesta.Server.Packets.Incoming;
internal static class IncomingPackets {
    // handshake
    public const short INIT_CRYPTO = 206;
    public const short GENERATE_KEY = 202;
    public const short TRY_LOGIN = 4;

    // players
    public const short GET_INFO = 7;
    public const short GET_ACCOUNT_PREFERENCES = 228;
    public const short GET_CREDITS = 8;

    // console
    public const short CONSOLE_INIT = 12;

    // habboclub
    public const short GET_CLUB = 26;

    // ecotron
    public const short GET_FURNI_RECYCLER_CONFIGURATION = 222;
    public const short GET_FURNI_RECYCLER_STATUS = 223;

    // roombadges
    public const short GET_AVAILABLE_BADGES = 157;

    // navigator
    public const short NAVIGATE = 150;

    // flats
    public const short GET_FLAT_INFO = 21;
    public const short GET_INTEREST = 182;
    public const short ROOM_DIRECTORY = 2;
    public const short TRY_FLAT = 57;
    public const short GO_TO_FLAT = 59;
}
