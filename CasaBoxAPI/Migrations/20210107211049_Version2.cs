using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CasaBoxAPI.Migrations
{
    public partial class Version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Mailadresse = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FuldeNavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefonnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    By = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Mailadresse);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BoxNummer = table.Column<int>(type: "int", nullable: false),
                    Mailadresse = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Bestillingstidspunkt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BoxNummer);
                    table.ForeignKey(
                        name: "FK_Booking_CasaBoxes_BoxNummer",
                        column: x => x.BoxNummer,
                        principalTable: "CasaBoxes",
                        principalColumn: "BoxNummer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Person_Mailadresse",
                        column: x => x.Mailadresse,
                        principalTable: "Person",
                        principalColumn: "Mailadresse",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Mailadresse",
                table: "Booking",
                column: "Mailadresse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
