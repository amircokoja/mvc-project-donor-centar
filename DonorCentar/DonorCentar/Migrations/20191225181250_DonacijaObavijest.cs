using Microsoft.EntityFrameworkCore.Migrations;

namespace DonorCentar.Migrations
{
    public partial class DonacijaObavijest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ObavijestId",
                table: "Donacija",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
