using Microsoft.EntityFrameworkCore.Migrations;

namespace ZaposleniMVC.Migrations
{
    public partial class Izmeni3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RasporedID",
                table: "Raspored");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RasporedID",
                table: "Raspored",
                nullable: false,
                defaultValue: 0);
        }
    }
}
