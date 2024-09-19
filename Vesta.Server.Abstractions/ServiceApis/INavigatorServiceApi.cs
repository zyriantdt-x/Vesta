using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Shared.Http.Responses.Navigator;

namespace Vesta.Server.ServiceApis;
public interface INavigatorServiceApi {
    Task<NavigatorCategoryHttpResponse?> GetNavigatorCategoryById( int id );
    Task<ICollection<NavigatorCategoryHttpResponse>?> GetNavigatorCategoriesByParentId( int parent_id );
}
