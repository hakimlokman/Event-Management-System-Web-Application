using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class FixKeyProblem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allowcations_CustomerBookings_BookingId",
                table: "Allowcations");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingFoods_CustomerBookings_BookingId",
                table: "BookingFoods");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "BookingFoods",
                newName: "CustomerBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingFoods_BookingId",
                table: "BookingFoods",
                newName: "IX_BookingFoods_CustomerBookingId");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Allowcations",
                newName: "CustomerBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Allowcations_BookingId",
                table: "Allowcations",
                newName: "IX_Allowcations_CustomerBookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allowcations_CustomerBookings_CustomerBookingId",
                table: "Allowcations",
                column: "CustomerBookingId",
                principalTable: "CustomerBookings",
                principalColumn: "CustomerBookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingFoods_CustomerBookings_CustomerBookingId",
                table: "BookingFoods",
                column: "CustomerBookingId",
                principalTable: "CustomerBookings",
                principalColumn: "CustomerBookingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allowcations_CustomerBookings_CustomerBookingId",
                table: "Allowcations");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingFoods_CustomerBookings_CustomerBookingId",
                table: "BookingFoods");

            migrationBuilder.RenameColumn(
                name: "CustomerBookingId",
                table: "BookingFoods",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingFoods_CustomerBookingId",
                table: "BookingFoods",
                newName: "IX_BookingFoods_BookingId");

            migrationBuilder.RenameColumn(
                name: "CustomerBookingId",
                table: "Allowcations",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Allowcations_CustomerBookingId",
                table: "Allowcations",
                newName: "IX_Allowcations_BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allowcations_CustomerBookings_BookingId",
                table: "Allowcations",
                column: "BookingId",
                principalTable: "CustomerBookings",
                principalColumn: "CustomerBookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingFoods_CustomerBookings_BookingId",
                table: "BookingFoods",
                column: "BookingId",
                principalTable: "CustomerBookings",
                principalColumn: "CustomerBookingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
