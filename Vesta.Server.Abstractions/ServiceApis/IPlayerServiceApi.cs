using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vesta.Shared.Http.Requests;
using Vesta.Shared.Http.Responses.Player;

namespace Vesta.Server.ServiceApis;
public interface IPlayerServiceApi {
    Task<LoginHttpResponse?> Login( LoginHttpRequest req );
    Task<UserObjectHttpResponse?> GetUserObject( int id );
}
