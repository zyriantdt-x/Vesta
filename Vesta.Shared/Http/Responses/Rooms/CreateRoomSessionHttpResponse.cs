using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vesta.Shared.Http.Responses.Rooms;
public class CreateRoomSessionHttpResponse {
    [JsonPropertyName("room_id")] public int RoomId { get; set; }
    [JsonPropertyName("model")] public string Model { get; set; }
    [JsonPropertyName( "wallpaper" )] public int Wallpaper { get; set; }
    [JsonPropertyName( "floor" )] public int Floor { get; set; }
}
