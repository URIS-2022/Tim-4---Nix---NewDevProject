using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Komisija.Migrations
{
    public partial class imigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Komisije",
                columns: table => new
                {
                    komisijaId = table.Column<Guid>(nullable: false),
                    nazivKomisije = table.Column<string>(maxLength: 50, nullable: false),
                    oznakaKomisije = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komisije", x => x.komisijaId);
                });

            migrationBuilder.CreateTable(
                name: "LicnostiKomisije",
                columns: table => new
                {
                    licnostKomisijeId = table.Column<Guid>(nullable: false),
                    imeLicnostiKomisije = table.Column<string>(maxLength: 50, nullable: false),
                    prezimeLicnostiKomisije = table.Column<string>(maxLength: 50, nullable: false),
                    funkcijaLicnostiKomisije = table.Column<string>(maxLength: 50, nullable: false),
                    kontaktLicnostiKomisije = table.Column<string>(nullable: false),
                    datumRodjenjaLicnostiKomisije = table.Column<DateTime>(nullable: false),
                    komisijaId = table.Column<Guid>(nullable: false),
                    oznakaKomisije = table.Column<string>(nullable: true),
                    KomisijaModelkomisijaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicnostiKomisije", x => x.licnostKomisijeId);
                    table.ForeignKey(
                        name: "FK_LicnostiKomisije_Komisije_KomisijaModelkomisijaId",
                        column: x => x.KomisijaModelkomisijaId,
                        principalTable: "Komisije",
                        principalColumn: "komisijaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LicnostiKomisije_KomisijaModelkomisijaId",
                table: "LicnostiKomisije",
                column: "KomisijaModelkomisijaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicnostiKomisije");

            migrationBuilder.DropTable(
                name: "Komisije");
        }
    }
}
