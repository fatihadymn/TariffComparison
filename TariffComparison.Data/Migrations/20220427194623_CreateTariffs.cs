using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TariffComparison.Data.Migrations
{
    public partial class CreateTariffs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tariff_comparison");

            migrationBuilder.CreateTable(
                name: "tariffs",
                schema: "tariff_comparison",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<int>(type: "integer", nullable: false),
                    base_cost = table.Column<decimal>(type: "money", nullable: false),
                    extra_cost = table.Column<decimal>(type: "money", nullable: false),
                    base_limit = table.Column<decimal>(type: "money", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamp", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tariffs", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tariffs",
                schema: "tariff_comparison");
        }
    }
}
