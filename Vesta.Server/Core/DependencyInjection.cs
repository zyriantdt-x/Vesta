using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Codec;
using Vesta.Server.Packets.Incoming;
using Vesta.Server.Packets.Incoming.Flats;
using Vesta.Server.Packets.Incoming.Handshake;
using Vesta.Server.Packets.Incoming.Navigator;
using Vesta.Server.Packets.Incoming.Player;
using Vesta.Server.Packets.Outgoing;
using Vesta.Server.ServiceApis;
using Vesta.Server.Sessions;
using Vesta.Server.Streams;

namespace Vesta.Server.Core;
internal static class DependencyInjection {
    public static void AddApplicationServices( this IServiceCollection services ) {
        services.AddSingleton<IApplication, Application>();

        services.AddSingleton<ChannelInitializer<IChannel>, ChannelInitialiser>(); // probs not best practice to name them to same, but I'm British so I will
        services.AddSingleton<ChannelHandlerAdapter, ChannelHandler>();

        services.AddCodecServices();
        services.AddSessionServices();
        services.AddPacketServices();
        services.AddServiceApis();
    }

    private static void AddCodecServices( this IServiceCollection services ) {
        services.AddSingleton<MessageToMessageEncoder<PacketComposerBase>, MessageEncoder>();
        services.AddSingleton<ByteToMessageDecoder, MessageDecoder>();
    }

    private static void AddSessionServices( this IServiceCollection services ) {
        services.AddSingleton<ISessionService, SessionService>();
    }

    private static void AddPacketServices( this IServiceCollection services ) {
        services.AddSingleton<IPacketProcessor, PacketProcessor>();

        // handshake
        services.AddSingleton<IPacketHandler, InitCryptoPacketHandler>();
        services.AddSingleton<IPacketHandler, GenerateKeyPacketHandler>();
        services.AddSingleton<IPacketHandler, TryLoginPacketHandler>();

        // player
        services.AddSingleton<IPacketHandler, GetInfoPacketHandler>();
        services.AddSingleton<IPacketHandler, GetCreditsPacketHandler>();

        // navi
        services.AddSingleton<IPacketHandler, NavigatePacketHandler>();

        // flats
        services.AddSingleton<IPacketHandler, GetFlatInfoPacketHandler>();
        services.AddSingleton<IPacketHandler, GetRoomInterestPacketHandler>();
        services.AddSingleton<IPacketHandler, RoomDirectoryPacketHandler>();
        services.AddSingleton<IPacketHandler, TryFlatPacketHandler>();
    }

    private static void AddServiceApis( this IServiceCollection services ) {
        services.AddSingleton<IPlayerServiceApi, PlayerServiceApi>();
        services.AddSingleton<IFlatServiceApi, FlatServiceApi>();
        services.AddSingleton<INavigatorServiceApi, NavigatorServiceApi>();
    }
}
