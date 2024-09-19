using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Vesta.Shared.Http.Requests;
public class LoginHttpRequest : HttpRequestBase {
    public required string Username { get; init; }
    public required string Password { get; init; }

    public override Dictionary<string, string> Compose() {
        return new() {
            { "username", this.Username },
            { "password", this.Password }
        };
    }
}
