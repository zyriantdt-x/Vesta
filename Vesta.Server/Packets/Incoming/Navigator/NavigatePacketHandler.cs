using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Server.Packets.Outgoing.Navigator;
using Vesta.Server.ServiceApis;
using Vesta.Server.Sessions;
using Vesta.Server.Streams;
using Vesta.Shared.Http.Responses.Navigator;
using Vesta.Shared.Http.Responses.Rooms;

namespace Vesta.Server.Packets.Incoming.Navigator;
internal class NavigatePacketHandler : IPacketHandler {
    public short Header => IncomingPackets.NAVIGATE;

    private readonly INavigatorServiceApi navigator_service;
    private readonly IFlatServiceApi flat_service;

    public NavigatePacketHandler( INavigatorServiceApi navigator_service,
                                  IFlatServiceApi flat_service ) {
        this.navigator_service = navigator_service;
        this.flat_service = flat_service;
    }

    public async Task Handle( ISession session, IRequest request ) {
        bool hide_full = request.ReadInt() == 1;
        int category_id = request.ReadInt();

        NavigatorCategoryHttpResponse? category = await this.navigator_service.GetNavigatorCategoryById( category_id );
        if( category == null )
            return;

        ICollection<GetFlatHttpResponse>? flats = await this.flat_service.GetFlatsByCategoryId( category_id );
        if( flats == null )
            return;

        ICollection<NavigatorCategoryHttpResponse>? subcategories = await this.navigator_service.GetNavigatorCategoriesByParentId( category_id );
        if( subcategories == null )
            return;

        _ = session.Send( new NavNodeInfoPacketComposer() {
            ParentCategory = category,
            Subcategories = subcategories,
            Flats = flats,
            HideFull = false
        } );
    }
}
