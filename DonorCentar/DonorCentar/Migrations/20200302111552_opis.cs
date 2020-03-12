using Microsoft.EntityFrameworkCore.Migrations;

namespace DonorCentar.Migrations
{
    public partial class opis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "DojamKorisnik",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opis",
                table: "DojamKorisnik");
        }
    }
}
