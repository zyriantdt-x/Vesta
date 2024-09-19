using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vesta.Shared.Http.Responses.Navigator;
public class NavigatorCategoryHttpResponse
{
    [JsonPropertyName("id")] public required int Id { get; set; }
    [JsonPropertyName("parent_id")] public required int ParentId { get; set; }
    [JsonPropertyName("name")] public required string Name { get; set; }
    [JsonPropertyName("is_node")] public required bool IsNode { get; set; }
    [JsonPropertyName("is_public_space")] public required bool IsPublicSpace { get; set; }
    [JsonPropertyName("is_trading_allowed")] public required bool IsTradingAllowed { get; set; }
    [JsonPropertyName("min_access")] public required int MinAccess { get; set; }
    [JsonPropertyName("min_assign")] public required int MinAssign { get; set; }
}
