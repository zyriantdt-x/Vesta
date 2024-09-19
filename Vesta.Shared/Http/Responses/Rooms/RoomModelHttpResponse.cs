using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vesta.Shared.Http.Responses.Rooms;
public class RoomModelHttpResponse {
    [JsonPropertyName( "id" )] public required int Id { get; set; }
    [JsonPropertyName( "model_id" )] public required string Name { get; set; }
    [JsonPropertyName( "door_x" )] public required int DoorX { get; set; }
    [JsonPropertyName( "door_y" )] public required int DoorY { get; set; }
    [JsonPropertyName( "door_z" )] public required int DoorZ { get; set; }
    [JsonPropertyName( "door_dir" )] public required int DoorDir { get; set; }
    [JsonPropertyName( "heightmap" )] public required string Heightmap { get; set; }
    [JsonPropertyName( "trigger_class" )] public required string TriggerClass { get; set; }
}
