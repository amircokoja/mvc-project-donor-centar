using Microsoft.EntityFrameworkCore.Migrations;

namespace DonorCentar.Migrations
{
    public partial class DodanOpis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Sadrzaj",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Sadrzaj");
        }
    }
}
