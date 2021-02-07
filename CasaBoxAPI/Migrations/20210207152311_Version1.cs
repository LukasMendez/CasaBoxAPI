using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CasaBoxAPI.Migrations
{
    public partial class Version1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brugere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emailadresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brugere", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CasaBoxType",
                columns: table => new
                {
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasaBoxType", x => x.Type);
                });

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
                name: "CasaBoxVariant",
                columns: table => new
                {
                    M2 = table.Column<double>(type: "float", nullable: false),
                    M3 = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pris = table.Column<int>(type: "int", nullable: false),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasaBoxVariant", x => new { x.M2, x.M3, x.Type });
                    table.ForeignKey(
                        name: "FK_CasaBoxVariant_CasaBoxType_Type",
                        column: x => x.Type,
                        principalTable: "CasaBoxType",
                        principalColumn: "Type",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CasaBoxes",
                columns: table => new
                {
                    BoxNummer = table.Column<int>(type: "int", nullable: false),
                    Ledig = table.Column<bool>(type: "bit", nullable: false),
                    M2 = table.Column<double>(type: "float", nullable: false),
                    M3 = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasaBoxes", x => x.BoxNummer);
                    table.ForeignKey(
                        name: "FK_CasaBoxes_CasaBoxVariant_M2_M3_Type",
                        columns: x => new { x.M2, x.M3, x.Type },
                        principalTable: "CasaBoxVariant",
                        principalColumns: new[] { "M2", "M3", "Type" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BoxNummer = table.Column<int>(type: "int", nullable: false),
                    Mailadresse = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingHistorik",
                columns: table => new
                {
                    BookingId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mailadresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bestillingstidspunkt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoxNummer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingHistorik", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_BookingHistorik_CasaBoxes_BoxNummer",
                        column: x => x.BoxNummer,
                        principalTable: "CasaBoxes",
                        principalColumn: "BoxNummer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Mailadresse",
                table: "Booking",
                column: "Mailadresse");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHistorik_BoxNummer",
                table: "BookingHistorik",
                column: "BoxNummer");

            migrationBuilder.CreateIndex(
                name: "IX_CasaBoxes_M2_M3_Type",
                table: "CasaBoxes",
                columns: new[] { "M2", "M3", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_CasaBoxVariant_Type",
                table: "CasaBoxVariant",
                column: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "BookingHistorik");

            migrationBuilder.DropTable(
                name: "Brugere");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "CasaBoxes");

            migrationBuilder.DropTable(
                name: "CasaBoxVariant");

            migrationBuilder.DropTable(
                name: "CasaBoxType");
        }
    }
}
