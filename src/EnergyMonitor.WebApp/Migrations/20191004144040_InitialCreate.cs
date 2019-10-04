using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnergyMonitor.WebApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnergyReadings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateUtc = table.Column<DateTime>(nullable: false),
                    Gas = table.Column<decimal>(nullable: true),
                    ElectricityHighRate = table.Column<decimal>(nullable: true),
                    ElectricityLowRate = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyReadings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnergyReadings");
        }
    }
}
