using Microsoft.EntityFrameworkCore.Migrations;

namespace DonorCentar.Migrations
{
    public partial class DonacijaIduSadrzaju : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donacija_Sadrzaj_SadrzajId",
                table: "Donacija");

            migrationBuilder.DropIndex(
                name: "IX_Donacija_SadrzajId",
                table: "Donacija");

            migrationBuilder.DropColumn(
                name: "SadrzajId",
                table: "Donacija");

            migrationBuilder.AddColumn<int>(
                name: "DonacijaId",
                table: "Sadrzaj",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_DonacijaId",
                table: "Sadrzaj",
                column: "DonacijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sadrzaj_Donacija_DonacijaId",
                table: "Sadrzaj",
                column: "DonacijaId",
                principalTable: "Donacija",
                principalColumn: "DonacijaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sadrzaj_Donacija_DonacijaId",
                table: "Sadrzaj");

            migrationBuilder.DropIndex(
                name: "IX_Sadrzaj_DonacijaId",
                table: "Sadrzaj");

            migrationBuilder.DropColumn(
                name: "DonacijaId",
                table: "Sadrzaj");

            migrationBuilder.AddColumn<int>(
                name: "SadrzajId",
                table: "Donacija",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_SadrzajId",
                table: "Donacija",
                column: "SadrzajId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donacija_Sadrzaj_SadrzajId",
                table: "Donacija",
                column: "SadrzajId",
                principalTable: "Sadrzaj",
                principalColumn: "SadrzajId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
