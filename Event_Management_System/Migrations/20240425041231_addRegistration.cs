using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class addRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationStatus",
                table: "CustomerRegistrations");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "CustomerRegistrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CustomerBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerRegistrationCustomerId",
                table: "CustomerBookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "BookingFoods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBookings_CustomerRegistrationCustomerId",
                table: "CustomerBookings",
                column: "CustomerRegistrationCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBookings_CustomerRegistrations_CustomerRegistrationCustomerId",
                table: "CustomerBookings",
                column: "CustomerRegistrationCustomerId",
                principalTable: "CustomerRegistrations",
                principalColumn: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBookings_CustomerRegistrations_CustomerRegistrationCustomerId",
                table: "CustomerBookings");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBookings_CustomerRegistrationCustomerId",
                table: "CustomerBookings");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "CustomerRegistrations");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerBookings");

            migrationBuilder.DropColumn(
                name: "CustomerRegistrationCustomerId",
                table: "CustomerBookings");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BookingFoods");

            migrationBuilder.AddColumn<bool>(
                name: "RegistrationStatus",
                table: "CustomerRegistrations",
                type: "bit",
                maxLength: 150,
                nullable: false,
                defaultValue: false);
        }
    }
}
