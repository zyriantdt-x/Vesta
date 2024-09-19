using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vesta.Shared.Http.Requests;
public abstract class HttpRequestBase {
    public abstract Dictionary<string, string> Compose();
}
