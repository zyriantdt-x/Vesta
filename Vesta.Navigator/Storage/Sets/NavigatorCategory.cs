﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Vesta.Navigator.Storage.Sets;

[Table("navigator_categories")]
public class NavigatorCategory {
    [Column("id")] public required int Id { get; set; }
    [Column("parent_id")] public required int ParentId { get; set; }
    [Column( "name" )] public required string Name { get; set; }
    [Column("is_node")] public required bool IsNode { get; set; }
    [Column("is_public_space")] public required bool IsPublicSpace { get; set; }
    [Column("is_trading_allowed")] public required bool IsTradingAllowed { get; set; }
    [Column("min_access")] public required int MinAccess { get; set; }
    [Column("min_assign")] public required int MinAssign { get; set; }
}
