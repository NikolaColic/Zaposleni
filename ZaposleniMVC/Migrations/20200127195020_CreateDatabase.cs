using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZaposleniMVC.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Raspored_Osobe_AdministratorOsobaID",
                table: "Raspored");

            migrationBuilder.DropForeignKey(
                name: "FK_Raspored_Osobe_ZaposleniOsobaID",
                table: "Raspored");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Osobe",
                table: "Osobe");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Osobe");

            migrationBuilder.RenameTable(
                name: "Osobe",
                newName: "Zaposleni");

            migrationBuilder.RenameColumn(
                name: "AdministratorOsobaID",
                table: "Raspored",
                newName: "AdministratorID");

            migrationBuilder.RenameIndex(
                name: "IX_Raspored_AdministratorOsobaID",
                table: "Raspored",
                newName: "IX_Raspored_AdministratorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zaposleni",
                table: "Zaposleni",
                column: "OsobaID");

            migrationBuilder.CreateTable(
                name: "Administratori",
                columns: table => new
                {
                    AdministratorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: false),
                    Prezime = table.Column<string>(nullable: false),
                    BrojTelefona = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Sifra = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administratori", x => x.AdministratorID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Raspored_Administratori_AdministratorID",
                table: "Raspored",
                column: "AdministratorID",
                principalTable: "Administratori",
                principalColumn: "AdministratorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Raspored_Zaposleni_ZaposleniOsobaID",
                table: "Raspored",
                column: "ZaposleniOsobaID",
                principalTable: "Zaposleni",
                principalColumn: "OsobaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Raspored_Administratori_AdministratorID",
                table: "Raspored");

            migrationBuilder.DropForeignKey(
                name: "FK_Raspored_Zaposleni_ZaposleniOsobaID",
                table: "Raspored");

            migrationBuilder.DropTable(
                name: "Administratori");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zaposleni",
                table: "Zaposleni");

            migrationBuilder.RenameTable(
                name: "Zaposleni",
                newName: "Osobe");

            migrationBuilder.RenameColumn(
                name: "AdministratorID",
                table: "Raspored",
                newName: "AdministratorOsobaID");

            migrationBuilder.RenameIndex(
                name: "IX_Raspored_AdministratorID",
                table: "Raspored",
                newName: "IX_Raspored_AdministratorOsobaID");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Osobe",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Osobe",
                table: "Osobe",
                column: "OsobaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Raspored_Osobe_AdministratorOsobaID",
                table: "Raspored",
                column: "AdministratorOsobaID",
                principalTable: "Osobe",
                principalColumn: "OsobaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Raspored_Osobe_ZaposleniOsobaID",
                table: "Raspored",
                column: "ZaposleniOsobaID",
                principalTable: "Osobe",
                principalColumn: "OsobaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
