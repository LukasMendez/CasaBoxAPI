using Microsoft.EntityFrameworkCore.Migrations;

namespace CasaBoxAPI.Migrations
{
    public partial class Version21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Person_Mailadresse",
                table: "Booking");

            migrationBuilder.AlterColumn<string>(
                name: "Mailadresse",
                table: "Booking",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Person_Mailadresse",
                table: "Booking",
                column: "Mailadresse",
                principalTable: "Person",
                principalColumn: "Mailadresse",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Person_Mailadresse",
                table: "Booking");

            migrationBuilder.AlterColumn<string>(
                name: "Mailadresse",
                table: "Booking",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Person_Mailadresse",
                table: "Booking",
                column: "Mailadresse",
                principalTable: "Person",
                principalColumn: "Mailadresse",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
