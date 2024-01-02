using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Huurders",
                columns: table => new
                {
                    HuurderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huurders", x => x.HuurderID);
                });

            migrationBuilder.CreateTable(
                name: "Huurdperiodes",
                columns: table => new
                {
                    HuurperiodeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EindDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aantaldagen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huurdperiodes", x => x.HuurperiodeID);
                });

            migrationBuilder.CreateTable(
                name: "Parken",
                columns: table => new
                {
                    ParkID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Naam = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    Locatie = table.Column<string>(type: "NVARCHAR(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parken", x => x.ParkID);
                });

            migrationBuilder.CreateTable(
                name: "Huizen",
                columns: table => new
                {
                    HuisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Straat = table.Column<string>(type: "NVARCHAR(250)", nullable: true),
                    Nummer = table.Column<int>(type: "int", nullable: false),
                    Actief = table.Column<bool>(type: "bit", nullable: false),
                    ParkID = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huizen", x => x.HuisID);
                    table.ForeignKey(
                        name: "FK_Huizen_Parken_ParkID",
                        column: x => x.ParkID,
                        principalTable: "Parken",
                        principalColumn: "ParkID");
                });

            migrationBuilder.CreateTable(
                name: "HuurContracten",
                columns: table => new
                {
                    HuurcontractId = table.Column<string>(type: "NVARCHAR(25)", nullable: false),
                    HuurperiodeID = table.Column<int>(type: "int", nullable: false),
                    HuurderID = table.Column<int>(type: "int", nullable: true),
                    HuisID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuurContracten", x => x.HuurcontractId);
                    table.ForeignKey(
                        name: "FK_HuurContracten_Huizen_HuisID",
                        column: x => x.HuisID,
                        principalTable: "Huizen",
                        principalColumn: "HuisID");
                    table.ForeignKey(
                        name: "FK_HuurContracten_Huurders_HuurderID",
                        column: x => x.HuurderID,
                        principalTable: "Huurders",
                        principalColumn: "HuurderID");
                    table.ForeignKey(
                        name: "FK_HuurContracten_Huurdperiodes_HuurperiodeID",
                        column: x => x.HuurperiodeID,
                        principalTable: "Huurdperiodes",
                        principalColumn: "HuurperiodeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Huizen_ParkID",
                table: "Huizen",
                column: "ParkID");

            migrationBuilder.CreateIndex(
                name: "IX_HuurContracten_HuisID",
                table: "HuurContracten",
                column: "HuisID");

            migrationBuilder.CreateIndex(
                name: "IX_HuurContracten_HuurderID",
                table: "HuurContracten",
                column: "HuurderID");

            migrationBuilder.CreateIndex(
                name: "IX_HuurContracten_HuurperiodeID",
                table: "HuurContracten",
                column: "HuurperiodeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HuurContracten");

            migrationBuilder.DropTable(
                name: "Huizen");

            migrationBuilder.DropTable(
                name: "Huurders");

            migrationBuilder.DropTable(
                name: "Huurdperiodes");

            migrationBuilder.DropTable(
                name: "Parken");
        }
    }
}
