using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZaposleniMVC.Migrations
{
    public partial class Izmeni2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Raspored",
                table: "Raspored");

            migrationBuilder.AlterColumn<int>(
                name: "RasporedID",
                table: "Raspored",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Raspored",
                table: "Raspored",
                column: "Datum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Raspored",
                table: "Raspored");

            migrationBuilder.AlterColumn<int>(
                name: "RasporedID",
                table: "Raspored",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Raspored",
                table: "Raspored",
                column: "RasporedID");
        }
    }
}
