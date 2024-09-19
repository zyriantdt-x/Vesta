using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vesta.Navigator.Migrations
{
    /// <inheritdoc />
    public partial class navigator_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "navigator_categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    parent_id = table.Column<int>(type: "int", nullable: false),
                    is_node = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_public_space = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_trading_allowed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    min_access = table.Column<int>(type: "int", nullable: false),
                    min_assign = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_navigator_categories", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "navigator_categories");
        }
    }
}
