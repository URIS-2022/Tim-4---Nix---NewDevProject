using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JavnoNadmetanje.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JavnaNadmetanja",
                columns: table => new
                {
                    JavnoNadmetanjeID = table.Column<Guid>(nullable: false),
                    DatumNadmetanja = table.Column<DateTime>(nullable: false),
                    VremePocetka = table.Column<DateTime>(nullable: false),
                    VremeKraja = table.Column<DateTime>(nullable: false),
                    Izuzeto = table.Column<bool>(nullable: false),
                    PocetnaCenaPoHektaru = table.Column<int>(nullable: false),
                    IzlicitiranaCena = table.Column<int>(nullable: false),
                    PeriodZakupa = table.Column<int>(nullable: false),
                    BrojUcesnika = table.Column<int>(nullable: false),
                    VisinaDopuneDepozita = table.Column<int>(nullable: false),
                    Krug = table.Column<int>(nullable: false),
                    Tip = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    KatastarskaOpstina = table.Column<int>(nullable: false),
                    KupacID = table.Column<Guid>(nullable: false),
                    AdresaID = table.Column<Guid>(nullable: false),
                    PrijavljeniKupci = table.Column<int>(nullable: false),
                    LicitacijaID = table.Column<Guid>(nullable: false),
                    ParcelaID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JavnaNadmetanja", x => x.JavnoNadmetanjeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JavnaNadmetanja");
        }
    }
}
