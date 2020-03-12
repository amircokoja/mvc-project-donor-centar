using Microsoft.EntityFrameworkCore.Migrations;

namespace DonorCentar.Migrations
{
    public partial class SadrzajDonacije : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donacija_Korisnik_DonorId",
                table: "Donacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Donacija_Korisnik_PrimalacId",
                table: "Donacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Donacija_Status_StatusId",
                table: "Donacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Donacija_VrstaDonacije_VrstaDonacijeId",
                table: "Donacija");

            migrationBuilder.DropIndex(
                name: "IX_Donacija_DonorId",
                table: "Donacija");

            migrationBuilder.DropIndex(
                name: "IX_Donacija_PrimalacId",
                table: "Donacija");

            migrationBuilder.DropIndex(
                name: "IX_Donacija_StatusId",
                table: "Donacija");

            migrationBuilder.DropIndex(
                name: "IX_Donacija_VrstaDonacijeId",
                table: "Donacija");

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "Donacija");

            migrationBuilder.DropColumn(
                name: "PrimalacId",
                table: "Donacija");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Donacija");

            migrationBuilder.DropColumn(
                name: "VrstaDonacijeId",
                table: "Donacija");

            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "Sadrzaj",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Sadrzaj",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VrstaDonacijeId",
                table: "Sadrzaj",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "Donacija",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_KorisnikId",
                table: "Sadrzaj",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_StatusId",
                table: "Sadrzaj",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_VrstaDonacijeId",
                table: "Sadrzaj",
                column: "VrstaDonacijeId");

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_KorisnikId",
                table: "Donacija",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donacija_Korisnik_KorisnikId",
                table: "Donacija",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sadrzaj_Korisnik_KorisnikId",
                table: "Sadrzaj",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sadrzaj_Status_StatusId",
                table: "Sadrzaj",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sadrzaj_VrstaDonacije_VrstaDonacijeId",
                table: "Sadrzaj",
                column: "VrstaDonacijeId",
                principalTable: "VrstaDonacije",
                principalColumn: "VrstaDonacijeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donacija_Korisnik_KorisnikId",
                table: "Donacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Sadrzaj_Korisnik_KorisnikId",
                table: "Sadrzaj");

            migrationBuilder.DropForeignKey(
                name: "FK_Sadrzaj_Status_StatusId",
                table: "Sadrzaj");

            migrationBuilder.DropForeignKey(
                name: "FK_Sadrzaj_VrstaDonacije_VrstaDonacijeId",
                table: "Sadrzaj");

            migrationBuilder.DropIndex(
                name: "IX_Sadrzaj_KorisnikId",
                table: "Sadrzaj");

            migrationBuilder.DropIndex(
                name: "IX_Sadrzaj_StatusId",
                table: "Sadrzaj");

            migrationBuilder.DropIndex(
                name: "IX_Sadrzaj_VrstaDonacijeId",
                table: "Sadrzaj");

            migrationBuilder.DropIndex(
                name: "IX_Donacija_KorisnikId",
                table: "Donacija");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Sadrzaj");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Sadrzaj");

            migrationBuilder.DropColumn(
                name: "VrstaDonacijeId",
                table: "Sadrzaj");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Donacija");

            migrationBuilder.AddColumn<int>(
                name: "DonorId",
                table: "Donacija",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrimalacId",
                table: "Donacija",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Donacija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VrstaDonacijeId",
                table: "Donacija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_DonorId",
                table: "Donacija",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_PrimalacId",
                table: "Donacija",
                column: "PrimalacId");

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_StatusId",
                table: "Donacija",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_VrstaDonacijeId",
                table: "Donacija",
                column: "VrstaDonacijeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donacija_Korisnik_DonorId",
                table: "Donacija",
                column: "DonorId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donacija_Korisnik_PrimalacId",
                table: "Donacija",
                column: "PrimalacId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donacija_Status_StatusId",
                table: "Donacija",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donacija_VrstaDonacije_VrstaDonacijeId",
                table: "Donacija",
                column: "VrstaDonacijeId",
                principalTable: "VrstaDonacije",
                principalColumn: "VrstaDonacijeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
