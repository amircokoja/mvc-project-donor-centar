using Microsoft.EntityFrameworkCore.Migrations;

namespace DonorCentar.Migrations
{
    public partial class StatusUDonaciju : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sadrzaj_Status_StatusId",
                table: "Sadrzaj");

            migrationBuilder.DropIndex(
                name: "IX_Sadrzaj_StatusId",
                table: "Sadrzaj");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Sadrzaj");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Donacija",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_StatusId",
                table: "Donacija",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donacija_Status_StatusId",
                table: "Donacija",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donacija_Status_StatusId",
                table: "Donacija");

            migrationBuilder.DropIndex(
                name: "IX_Donacija_StatusId",
                table: "Donacija");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Donacija");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Sadrzaj",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_StatusId",
                table: "Sadrzaj",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sadrzaj_Status_StatusId",
                table: "Sadrzaj",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
