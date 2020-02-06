using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZaposleniMVC.Migrations
{
    public partial class KompanijaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KompanijaID",
                table: "Zaposleni",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KompanijaID",
                table: "Administratori",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Kompanija",
                columns: table => new
                {
                    KompanijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false),
                    MaticniBroj = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true),
                    Delatnost = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kompanija", x => x.KompanijaID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zaposleni_KompanijaID",
                table: "Zaposleni",
                column: "KompanijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Administratori_KompanijaID",
                table: "Administratori",
                column: "KompanijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Administratori_Kompanija_KompanijaID",
                table: "Administratori",
                column: "KompanijaID",
                principalTable: "Kompanija",
                principalColumn: "KompanijaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zaposleni_Kompanija_KompanijaID",
                table: "Zaposleni",
                column: "KompanijaID",
                principalTable: "Kompanija",
                principalColumn: "KompanijaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administratori_Kompanija_KompanijaID",
                table: "Administratori");

            migrationBuilder.DropForeignKey(
                name: "FK_Zaposleni_Kompanija_KompanijaID",
                table: "Zaposleni");

            migrationBuilder.DropTable(
                name: "Kompanija");

            migrationBuilder.DropIndex(
                name: "IX_Zaposleni_KompanijaID",
                table: "Zaposleni");

            migrationBuilder.DropIndex(
                name: "IX_Administratori_KompanijaID",
                table: "Administratori");

            migrationBuilder.DropColumn(
                name: "KompanijaID",
                table: "Zaposleni");

            migrationBuilder.DropColumn(
                name: "KompanijaID",
                table: "Administratori");
        }
    }
}
