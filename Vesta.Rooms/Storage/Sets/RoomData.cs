﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vesta.Rooms.Storage.Sets;

[Table("room_data")]
public class RoomData {
    [Key]
    [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
    [Column( "id" )]
    public int Id { get; set; }

    [Required]
    [Column( "owner_id", TypeName = "varchar(11)" )]
    public required string OwnerId { get; set; }

    [Column( "category" )]
    public int Category { get; set; } = 2;

    [Required]
    [Column( "name", TypeName = "varchar(255)" )]
    public required string Name { get; set; }

    [Required]
    [Column( "description", TypeName = "varchar(255)" )]
    public required string Description { get; set; }

    [Required]
    [Column( "model", TypeName = "varchar(255)" )]
    public required string Model { get; set; }

    [Column( "ccts", TypeName = "varchar(255)" )]
    public required string Ccts { get; set; } = String.Empty;

    [Column( "wallpaper" )]
    public int Wallpaper { get; set; } = 0;

    [Column( "floor" )]
    public int Floor { get; set; } = 0;

    [Column( "showname" )]
    public bool ShowName { get; set; } = true;

    [Column( "superusers" )]
    public bool SuperUsers { get; set; } = false;

    [Column( "accesstype" )]
    public int AccessType { get; set; } = 0;

    [Column( "password", TypeName = "varchar(255)" )]
    public string Password { get; set; } = String.Empty;

    [Column( "visitors_now" )]
    public int VisitorsNow { get; set; } = 0;

    [Column( "visitors_max" )]
    public int VisitorsMax { get; set; } = 25;

    [Column( "rating" )]
    public int Rating { get; set; } = 0;

    [Column( "is_hidden" )]
    public bool IsHidden { get; set; } = false;

    [Column( "created_at" )]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Column( "updated_at" )]
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
