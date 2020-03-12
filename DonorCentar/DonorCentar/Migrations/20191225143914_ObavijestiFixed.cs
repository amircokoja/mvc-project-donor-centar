using Microsoft.EntityFrameworkCore.Migrations;

namespace DonorCentar.Migrations
{
    public partial class ObavijestiFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obavijest_Korisnik_KorisnikId",
                table: "Obavijest");

            migrationBuilder.DropIndex(
                name: "IX_Obavijest_KorisnikId",
                table: "Obavijest");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Obavijest");

            migrationBuilder.AddColumn<int>(
                name: "OdKorisnikId",
                table: "Obavijest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZaKorisnikId",
                table: "Obavijest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_OdKorisnikId",
                table: "Obavijest",
                column: "OdKorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_ZaKorisnikId",
                table: "Obavijest",
                column: "ZaKorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obavijest_Korisnik_OdKorisnikId",
                table: "Obavijest",
                column: "OdKorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Obavijest_Korisnik_ZaKorisnikId",
                table: "Obavijest",
                column: "ZaKorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obavijest_Korisnik_OdKorisnikId",
                table: "Obavijest");

            migrationBuilder.DropForeignKey(
                name: "FK_Obavijest_Korisnik_ZaKorisnikId",
                table: "Obavijest");

            migrationBuilder.DropIndex(
                name: "IX_Obavijest_OdKorisnikId",
                table: "Obavijest");

            migrationBuilder.DropIndex(
                name: "IX_Obavijest_ZaKorisnikId",
                table: "Obavijest");

            migrationBuilder.DropColumn(
                name: "OdKorisnikId",
                table: "Obavijest");

            migrationBuilder.DropColumn(
                name: "ZaKorisnikId",
                table: "Obavijest");

            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "Obavijest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_KorisnikId",
                table: "Obavijest",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obavijest_Korisnik_KorisnikId",
                table: "Obavijest",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
