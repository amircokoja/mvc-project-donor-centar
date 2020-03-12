using Microsoft.EntityFrameworkCore.Migrations;

namespace DonorCentar.Migrations
{
    public partial class updatev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donacija_Obavijest_ObavijestId",
                table: "Donacija");

            migrationBuilder.DropIndex(
                name: "IX_Donacija_ObavijestId",
                table: "Donacija");

            migrationBuilder.DropColumn(
                name: "ObavijestId",
                table: "Donacija");

            migrationBuilder.AddColumn<int>(
                name: "DonacijaId",
                table: "Obavijest",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_DonacijaId",
                table: "Obavijest",
                column: "DonacijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Obavijest_Donacija_DonacijaId",
                table: "Obavijest",
                column: "DonacijaId",
                principalTable: "Donacija",
                principalColumn: "DonacijaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obavijest_Donacija_DonacijaId",
                table: "Obavijest");

            migrationBuilder.DropIndex(
                name: "IX_Obavijest_DonacijaId",
                table: "Obavijest");

            migrationBuilder.DropColumn(
                name: "DonacijaId",
                table: "Obavijest");

            migrationBuilder.AddColumn<int>(
                name: "ObavijestId",
                table: "Donacija",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_ObavijestId",
                table: "Donacija",
                column: "ObavijestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donacija_Obavijest_ObavijestId",
                table: "Donacija",
                column: "ObavijestId",
                principalTable: "Obavijest",
                principalColumn: "ObavijestId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
