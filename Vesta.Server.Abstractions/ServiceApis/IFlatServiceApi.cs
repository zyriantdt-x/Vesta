using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Shared.Http.Responses.Rooms;

namespace Vesta.Server.ServiceApis;
public interface IFlatServiceApi {
    Task<ICollection<GetFlatHttpResponse>?> GetFlatsByCategoryId( int category_id );
    Task<GetFlatHttpResponse?> GetFlatById( int id );

    Task<RoomModelHttpResponse?> GetRoomModelByName( string name );
}
