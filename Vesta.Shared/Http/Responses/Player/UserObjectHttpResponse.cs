using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vesta.Shared.Http.Responses.Player;
public class UserObjectHttpResponse
{
    [JsonPropertyName("id")] public required int Id { get; init; }
    [JsonPropertyName("username")] public required string Username { get; init; }
    [JsonPropertyName("figure")] public required string Figure { get; init; }
    [JsonPropertyName("sex")] public required char Sex { get; init; } // 1 male 0 female
    [JsonPropertyName("mission")] public required string Mission { get; init; }
    [JsonPropertyName("tickets")] public required int Tickets { get; init; }
    [JsonPropertyName("pool_figure")] public required string PoolFigure { get; init; }
    [JsonPropertyName("film")] public required int Film { get; init; }
    [JsonPropertyName("receive_news")] public required bool ReceiveNews { get; init; }
    [JsonPropertyName("credits")] public required int Credits { get; init; }
}
