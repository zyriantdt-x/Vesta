using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vesta.Shared.Http.Responses.Rooms;
public class GetFlatHttpResponse
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    [JsonPropertyName("owner_id")]
    public required int OwnerId { get; set; }

    [JsonPropertyName("category")]
    public required int Category { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("description")]
    public required string Description { get; set; }

    [JsonPropertyName("model")]
    public required string Model { get; set; }

    [JsonPropertyName("ccts")]
    public string? Ccts { get; set; }

    [JsonPropertyName("wallpaper")]
    public required int Wallpaper { get; set; }

    [JsonPropertyName("floor")]
    public required int Floor { get; set; }

    [JsonPropertyName("showname")]
    public required bool ShowName { get; set; }

    [JsonPropertyName("superusers")]
    public required bool SuperUsers { get; set; }

    [JsonPropertyName("accesstype")]
    public required int AccessType { get; set; } = 0;

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("visitors_now")]
    public required int VisitorsNow { get; set; }

    [JsonPropertyName("visitors_max")]
    public required int VisitorsMax { get; set; }

    [JsonPropertyName("rating")]
    public required int Rating { get; set; }

    [JsonPropertyName("is_hidden")]
    public required bool IsHidden { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }
}
