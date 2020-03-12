using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DonorCentar.Migrations
{
    public partial class Dojam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dojam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrstaDojma = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dojam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DojamKorisnik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DojamId = table.Column<int>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    DonacijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DojamKorisnik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DojamKorisnik_Dojam_DojamId",
                        column: x => x.DojamId,
                        principalTable: "Dojam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DojamKorisnik_Donacija_DonacijaId",
                        column: x => x.DonacijaId,
                        principalTable: "Donacija",
                        principalColumn: "DonacijaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DojamKorisnik_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DojamKorisnik_DojamId",
                table: "DojamKorisnik",
                column: "DojamId");

            migrationBuilder.CreateIndex(
                name: "IX_DojamKorisnik_DonacijaId",
                table: "DojamKorisnik",
                column: "DonacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_DojamKorisnik_KorisnikId",
                table: "DojamKorisnik",
                column: "KorisnikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DojamKorisnik");

            migrationBuilder.DropTable(
                name: "Dojam");
        }
    }
}
