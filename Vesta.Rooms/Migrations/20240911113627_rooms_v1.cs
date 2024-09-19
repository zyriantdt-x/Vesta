using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vesta.Rooms.Migrations
{
    /// <inheritdoc />
    public partial class rooms_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "room_data",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    owner_id = table.Column<string>(type: "varchar(11)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    category = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    model = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ccts = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    wallpaper = table.Column<int>(type: "int", nullable: true),
                    floor = table.Column<int>(type: "int", nullable: true),
                    showname = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    superusers = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    accesstype = table.Column<int>(type: "int", nullable: true),
                    password = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    visitors_now = table.Column<int>(type: "int", nullable: true),
                    visitors_max = table.Column<int>(type: "int", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: false),
                    is_hidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_data", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "room_data");
        }
    }
}
