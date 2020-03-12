using Microsoft.EntityFrameworkCore.Migrations;

namespace DonorCentar.Migrations
{
    public partial class InformacijeTransporta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InformacijeId",
                table: "Donacija",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InformacijeTransporta",
                columns: table => new
                {
                    InformacijeTransportaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacijeTransporta", x => x.InformacijeTransportaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_InformacijeId",
                table: "Donacija",
                column: "InformacijeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donacija_InformacijeTransporta_InformacijeId",
                table: "Donacija",
                column: "InformacijeId",
                principalTable: "InformacijeTransporta",
                principalColumn: "InformacijeTransportaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donacija_InformacijeTransporta_InformacijeId",
                table: "Donacija");

            migrationBuilder.DropTable(
                name: "InformacijeTransporta");

            migrationBuilder.DropIndex(
                name: "IX_Donacija_InformacijeId",
                table: "Donacija");

            migrationBuilder.DropColumn(
                name: "InformacijeId",
                table: "Donacija");
        }
    }
}
