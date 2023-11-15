using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class prva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cijena = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnik_KorisnickiNalog_Id",
                        column: x => x.Id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    NarudzbaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    ProizvodId = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ukupno = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.NarudzbaId);
                    table.ForeignKey(
                        name: "FK_Narudzba_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narudzba_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_KorisnikId",
                table: "Narudzba",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_ProizvodId",
                table: "Narudzba",
                column: "ProizvodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");
        }
    }
}
