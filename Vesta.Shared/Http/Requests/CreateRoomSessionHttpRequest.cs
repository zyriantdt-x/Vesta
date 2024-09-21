using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vesta.Shared.Http.Requests;
public class CreateRoomSessionHttpRequest {
    public int UserId { get; set; }
    public int RoomId { get; set; }

    public Dictionary<string, string> Compose()
        => new() {
            { "userid", this.UserId.ToString() },
            { "roomid", this.RoomId.ToString() }
        };
}

