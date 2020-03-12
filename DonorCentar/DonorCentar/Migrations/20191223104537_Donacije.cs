using Microsoft.EntityFrameworkCore.Migrations;

namespace DonorCentar.Migrations
{
    public partial class Donacije : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "TipDonacije",
                columns: table => new
                {
                    TipDonacijeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipDonacije", x => x.TipDonacijeId);
                });

            migrationBuilder.CreateTable(
                name: "VrstaDonacije",
                columns: table => new
                {
                    VrstaDonacijeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrsta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaDonacije", x => x.VrstaDonacijeId);
                });

            migrationBuilder.CreateTable(
                name: "Sadrzaj",
                columns: table => new
                {
                    SadrzajId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipDonacijeId = table.Column<int>(nullable: false),
                    Kolicina = table.Column<decimal>(nullable: false),
                    JedinicaMjere = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sadrzaj", x => x.SadrzajId);
                    table.ForeignKey(
                        name: "FK_Sadrzaj_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sadrzaj_TipDonacije_TipDonacijeId",
                        column: x => x.TipDonacijeId,
                        principalTable: "TipDonacije",
                        principalColumn: "TipDonacijeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Donacija",
                columns: table => new
                {
                    DonacijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimalacId = table.Column<int>(nullable: true),
                    DonorId = table.Column<int>(nullable: true),
                    SadrzajId = table.Column<int>(nullable: true),
                    TransportId = table.Column<int>(nullable: true),
                    VrstaDonacijeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donacija", x => x.DonacijaId);
                    table.ForeignKey(
                        name: "FK_Donacija_Korisnik_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donacija_Korisnik_PrimalacId",
                        column: x => x.PrimalacId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donacija_Sadrzaj_SadrzajId",
                        column: x => x.SadrzajId,
                        principalTable: "Sadrzaj",
                        principalColumn: "SadrzajId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donacija_Korisnik_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donacija_VrstaDonacije_VrstaDonacijeId",
                        column: x => x.VrstaDonacijeId,
                        principalTable: "VrstaDonacije",
                        principalColumn: "VrstaDonacijeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_DonorId",
                table: "Donacija",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_PrimalacId",
                table: "Donacija",
                column: "PrimalacId");

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_SadrzajId",
                table: "Donacija",
                column: "SadrzajId");

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_TransportId",
                table: "Donacija",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_VrstaDonacijeId",
                table: "Donacija",
                column: "VrstaDonacijeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_StatusId",
                table: "Sadrzaj",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_TipDonacijeId",
                table: "Sadrzaj",
                column: "TipDonacijeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donacija");

            migrationBuilder.DropTable(
                name: "Sadrzaj");

            migrationBuilder.DropTable(
                name: "VrstaDonacije");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "TipDonacije");
        }
    }
}
