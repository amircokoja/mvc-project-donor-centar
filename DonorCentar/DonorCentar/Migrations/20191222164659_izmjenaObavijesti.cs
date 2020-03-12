using Microsoft.EntityFrameworkCore.Migrations;

namespace DonorCentar.Migrations
{
    public partial class izmjenaObavijesti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipKorisnika",
                table: "Obavijest");

            migrationBuilder.AddColumn<int>(
                name: "TipKorisnikaId",
                table: "Obavijest",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipKorisnikaId",
                table: "Obavijest");

            migrationBuilder.AddColumn<string>(
                name: "TipKorisnika",
                table: "Obavijest",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
