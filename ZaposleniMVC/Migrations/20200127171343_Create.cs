using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZaposleniMVC.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Osobe",
                columns: table => new
                {
                    OsobaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    Adresa = table.Column<string>(nullable: true),
                    BrojTelefona = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Sifra = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Pozicija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osobe", x => x.OsobaID);
                });

            migrationBuilder.CreateTable(
                name: "Raspored",
                columns: table => new
                {
                    Datum = table.Column<DateTime>(nullable: false),
                    AdministratorOsobaID = table.Column<int>(nullable: true),
                    ZaposleniOsobaID = table.Column<int>(nullable: true),
                    Smena = table.Column<string>(nullable: false),
                    VremePrijave = table.Column<DateTime>(nullable: false),
                    Kasni = table.Column<bool>(nullable: false),
                    Obavestenje = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raspored", x => x.Datum);
                    table.ForeignKey(
                        name: "FK_Raspored_Osobe_AdministratorOsobaID",
                        column: x => x.AdministratorOsobaID,
                        principalTable: "Osobe",
                        principalColumn: "OsobaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Raspored_Osobe_ZaposleniOsobaID",
                        column: x => x.ZaposleniOsobaID,
                        principalTable: "Osobe",
                        principalColumn: "OsobaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Raspored_AdministratorOsobaID",
                table: "Raspored",
                column: "AdministratorOsobaID");

            migrationBuilder.CreateIndex(
                name: "IX_Raspored_ZaposleniOsobaID",
                table: "Raspored",
                column: "ZaposleniOsobaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Raspored");

            migrationBuilder.DropTable(
                name: "Osobe");
        }
    }
}
