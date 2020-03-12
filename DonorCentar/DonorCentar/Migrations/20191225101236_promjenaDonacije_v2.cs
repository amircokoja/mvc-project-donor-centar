using Microsoft.EntityFrameworkCore.Migrations;

namespace DonorCentar.Migrations
{
    public partial class promjenaDonacije_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sadrzaj");

            migrationBuilder.CreateTable(
                name: "Donacija",
                columns: table => new
                {
                    DonacijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipDonacijeId = table.Column<int>(nullable: false),
                    Opis = table.Column<string>(nullable: false),
                    Kolicina = table.Column<decimal>(nullable: false),
                    JedinicaMjere = table.Column<int>(nullable: false),
                    PrimalacId = table.Column<int>(nullable: true),
                    DonorId = table.Column<int>(nullable: true),
                    TransportId = table.Column<int>(nullable: true),
                    VrstaDonacijeId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
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
                        name: "FK_Donacija_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donacija_TipDonacije_TipDonacijeId",
                        column: x => x.TipDonacijeId,
                        principalTable: "TipDonacije",
                        principalColumn: "TipDonacijeId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Donacija_StatusId",
                table: "Donacija",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_TipDonacijeId",
                table: "Donacija",
                column: "TipDonacijeId");

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_TransportId",
                table: "Donacija",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_Donacija_VrstaDonacijeId",
                table: "Donacija",
                column: "VrstaDonacijeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donacija");

            migrationBuilder.CreateTable(
                name: "Sadrzaj",
                columns: table => new
                {
                    SadrzajId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonorId = table.Column<int>(type: "int", nullable: true),
                    JedinicaMjere = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimalacId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    TipDonacijeId = table.Column<int>(type: "int", nullable: false),
                    TransportId = table.Column<int>(type: "int", nullable: true),
                    VrstaDonacijeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sadrzaj", x => x.SadrzajId);
                    table.ForeignKey(
                        name: "FK_Sadrzaj_Korisnik_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sadrzaj_Korisnik_PrimalacId",
                        column: x => x.PrimalacId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_Sadrzaj_Korisnik_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sadrzaj_VrstaDonacije_VrstaDonacijeId",
                        column: x => x.VrstaDonacijeId,
                        principalTable: "VrstaDonacije",
                        principalColumn: "VrstaDonacijeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_DonorId",
                table: "Sadrzaj",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_PrimalacId",
                table: "Sadrzaj",
                column: "PrimalacId");

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_StatusId",
                table: "Sadrzaj",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_TipDonacijeId",
                table: "Sadrzaj",
                column: "TipDonacijeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_TransportId",
                table: "Sadrzaj",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_Sadrzaj_VrstaDonacijeId",
                table: "Sadrzaj",
                column: "VrstaDonacijeId");
        }
    }
}
