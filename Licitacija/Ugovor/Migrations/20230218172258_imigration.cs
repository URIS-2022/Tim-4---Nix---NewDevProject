using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ugovor.Migrations
{
    public partial class imigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ugovori",
                columns: table => new
                {
                    UgovorId = table.Column<Guid>(nullable: false),
                    LicitacijaId = table.Column<Guid>(nullable: false),
                    TipGarancije = table.Column<int>(nullable: false),
                    LiceId = table.Column<Guid>(nullable: false),
                    RokDospeca = table.Column<int>(nullable: false),
                    ZavodniBroj = table.Column<string>(nullable: false),
                    DatumZavodjenja = table.Column<DateTime>(nullable: false),
                    RokZaVracanjeZemljista = table.Column<DateTime>(nullable: false),
                    MestoPotpisivanja = table.Column<string>(nullable: true),
                    DatumPotpisa = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ugovori", x => x.UgovorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ugovori");
        }
    }
}
