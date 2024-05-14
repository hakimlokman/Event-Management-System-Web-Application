using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class MathayNostoMama : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingServices_CustomerBookings_BookingId",
                table: "BookingServices");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingServices_Services_ServicesId",
                table: "BookingServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBookings_CustomerRegistrations_CustomerRegistrationCustomerId",
                table: "CustomerBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_CustomerBookings_BookingId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBookings_CustomerRegistrationCustomerId",
                table: "CustomerBookings");

            migrationBuilder.DropColumn(
                name: "CustomerRegistrationCustomerId",
                table: "CustomerBookings");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Payments",
                newName: "CustomerBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                newName: "IX_Payments_CustomerBookingId");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "BookingServices",
                newName: "CustomerBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingServices_BookingId",
                table: "BookingServices",
                newName: "IX_BookingServices_CustomerBookingId");

            migrationBuilder.AlterColumn<int>(
                name: "ServicesId",
                table: "BookingServices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingServices_CustomerBookings_CustomerBookingId",
                table: "BookingServices",
                column: "CustomerBookingId",
                principalTable: "CustomerBookings",
                principalColumn: "CustomerBookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingServices_Services_ServicesId",
                table: "BookingServices",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_CustomerBookings_CustomerBookingId",
                table: "Payments",
                column: "CustomerBookingId",
                principalTable: "CustomerBookings",
                principalColumn: "CustomerBookingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingServices_CustomerBookings_CustomerBookingId",
                table: "BookingServices");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingServices_Services_ServicesId",
                table: "BookingServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_CustomerBookings_CustomerBookingId",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "CustomerBookingId",
                table: "Payments",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_CustomerBookingId",
                table: "Payments",
                newName: "IX_Payments_BookingId");

            migrationBuilder.RenameColumn(
                name: "CustomerBookingId",
                table: "BookingServices",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_BookingServices_CustomerBookingId",
                table: "BookingServices",
                newName: "IX_BookingServices_BookingId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerRegistrationCustomerId",
                table: "CustomerBookings",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ServicesId",
                table: "BookingServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBookings_CustomerRegistrationCustomerId",
                table: "CustomerBookings",
                column: "CustomerRegistrationCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingServices_CustomerBookings_BookingId",
                table: "BookingServices",
                column: "BookingId",
                principalTable: "CustomerBookings",
                principalColumn: "CustomerBookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingServices_Services_ServicesId",
                table: "BookingServices",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "ServicesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBookings_CustomerRegistrations_CustomerRegistrationCustomerId",
                table: "CustomerBookings",
                column: "CustomerRegistrationCustomerId",
                principalTable: "CustomerRegistrations",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_CustomerBookings_BookingId",
                table: "Payments",
                column: "BookingId",
                principalTable: "CustomerBookings",
                principalColumn: "CustomerBookingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
