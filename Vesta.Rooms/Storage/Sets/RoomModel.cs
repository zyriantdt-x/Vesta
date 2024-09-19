using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vesta.Rooms.Storage.Sets;

[Table("room_models")]
public class RoomModel {
    [Column("id")] public required int Id { get; set; }
    [Column("model_id")] public required string Name { get; set; }
    [Column("door_x")] public required int DoorX { get; set; }
    [Column("door_y")] public required int DoorY { get; set; }
    [Column("door_z")] public required int DoorZ { get; set; }
    [Column("door_dir")] public required int DoorDir { get; set; }
    [Column("heightmap")] public required string Heightmap { get; set; }
    [Column("trigger_class")] public required string TriggerClass { get; set; }
}
