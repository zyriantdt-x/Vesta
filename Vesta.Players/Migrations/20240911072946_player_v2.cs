using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vesta.Players.Migrations
{
    /// <inheritdoc />
    public partial class player_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "credits",
                table: "player_data",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "credits",
                table: "player_data");
        }
    }
}
