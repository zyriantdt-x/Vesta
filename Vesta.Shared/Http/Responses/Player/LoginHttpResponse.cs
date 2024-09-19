using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vesta.Shared.Http.Responses.Player;
public class LoginHttpResponse
{
    [JsonPropertyName("player_id")] public required int PlayerId { get; init; }

    public string Compose()
        => JsonSerializer.Serialize(this);
}
