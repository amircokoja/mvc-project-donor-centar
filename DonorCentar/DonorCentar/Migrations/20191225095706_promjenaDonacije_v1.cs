using Microsoft.EntityFrameworkCore.Migrations;

namespace DonorCentar.Migrations
{
    public partial class promjenaDonacije_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sadrzaj_Donacija_DonacijaId",
                table: "Sadrzaj");

            migrationBuilder.DropForeignKey(
                name: "FK_Sadrzaj_Korisnik_KorisnikId",
                table: "Sadrzaj");

            migrationBuilder.DropTable(
                name: "Donacija");

            migrationBuilder.DropIndex(
                name: "IX_Sadrzaj_DonacijaId",
                table: "Sadrzaj");

            migrationBuilder.DropIndex(
                name: "IX_Sadrzaj_KorisnikId",
                table: "Sadrzaj");

            migrationBuilder.DropColumn(
                name: "DonacijaId",
                table: "Sadrzaj");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Sadrzaj");

            migrationBuilder.AddColumn<int>(
                name: "DonorId",
                table: "Sadrzaj",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrimalacId",
                table: "Sadrzaj",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransportId",
                table: "Sadrzaj",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_DonorId",
                table: "Sadrzaj",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_PrimalacId",
                table: "Sadrzaj",
                column: "PrimalacId");

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_TransportId",
                table: "Sadrzaj",
                column: "TransportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sadrzaj_Korisnik_DonorId",
                table: "Sadrzaj",
                column: "DonorId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sadrzaj_Korisnik_PrimalacId",
                table: "Sadrzaj",
                column: "PrimalacId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sadrzaj_Korisnik_TransportId",
                table: "Sadrzaj",
                column: "TransportId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sadrzaj_Korisnik_DonorId",
                table: "Sadrzaj");

            migrationBuilder.DropForeignKey(
                name: "FK_Sadrzaj_Korisnik_PrimalacId",
                table: "Sadrzaj");

            migrationBuilder.DropForeignKey(
                name: "FK_Sadrzaj_Korisnik_TransportId",
                table: "Sadrzaj");

            migrationBuilder.DropIndex(
                name: "IX_Sadrzaj_DonorId",
                table: "Sadrzaj");

            migrationBuilder.DropIndex(
                name: "IX_Sadrzaj_PrimalacId",
                table: "Sadrzaj");

            migrationBuilder.DropIndex(
                name: "IX_Sadrzaj_TransportId",
                table: "Sadrzaj");

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "Sadrzaj");

            migrationBuilder.DropColumn(
                name: "PrimalacId",
                table: "Sadrzaj");

            migrationBuilder.DropColumn(
                name: "TransportId",
                table: "Sadrzaj");

            migrationBuilder.AddColumn<int>(
                name: "DonacijaId",
                table: "Sadrzaj",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "Sadrzaj",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Donacija",
                columns: table => new
                {
                    DonacijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    TransportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donacija", x => x.DonacijaId);
                    table.ForeignKey(
                        name: "FK_Donacija_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donacija_Korisnik_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_DonacijaId",
                table: "Sadrzaj",
                column: "DonacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_KorisnikId",
                table: "Sadrzaj",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_KorisnikId",
                table: "Donacija",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_TransportId",
                table: "Donacija",
                column: "TransportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sadrzaj_Donacija_DonacijaId",
                table: "Sadrzaj",
                column: "DonacijaId",
                principalTable: "Donacija",
                principalColumn: "DonacijaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sadrzaj_Korisnik_KorisnikId",
                table: "Sadrzaj",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
