using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZaposleniMVC.Migrations
{
    public partial class Upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Raspored",
                table: "Raspored");

            migrationBuilder.AddColumn<int>(
                name: "RasporedID",
                table: "Raspored",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Raspored",
                table: "Raspored",
                column: "RasporedID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Raspored",
                table: "Raspored");

            migrationBuilder.DropColumn(
                name: "RasporedID",
                table: "Raspored");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Raspored",
                table: "Raspored",
                column: "Datum");
        }
    }
}
