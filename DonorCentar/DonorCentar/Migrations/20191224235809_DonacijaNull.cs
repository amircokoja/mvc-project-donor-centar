using Microsoft.EntityFrameworkCore.Migrations;

namespace DonorCentar.Migrations
{
    public partial class DonacijaNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sadrzaj_Donacija_DonacijaId",
                table: "Sadrzaj");

            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "Sadrzaj",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DonacijaId",
                table: "Sadrzaj",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sadrzaj_Donacija_DonacijaId",
                table: "Sadrzaj",
                column: "DonacijaId",
                principalTable: "Donacija",
                principalColumn: "DonacijaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sadrzaj_Donacija_DonacijaId",
                table: "Sadrzaj");

            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "Sadrzaj",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "DonacijaId",
                table: "Sadrzaj",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sadrzaj_Donacija_DonacijaId",
                table: "Sadrzaj",
                column: "DonacijaId",
                principalTable: "Donacija",
                principalColumn: "DonacijaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
