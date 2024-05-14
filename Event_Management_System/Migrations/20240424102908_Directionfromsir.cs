using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class Directionfromsir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingServices_Services_ServicesId",
                table: "BookingServices");

            migrationBuilder.DropIndex(
                name: "IX_BookingServices_ServicesId",
                table: "BookingServices");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "NumberOfDays",
                table: "CustomerBookings");

            migrationBuilder.AlterColumn<double>(
                name: "UnitPrice",
                table: "Services",
                type: "float",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "CustomerBookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "CustomerBookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "CustomerBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "ServicesId",
                table: "BookingServices",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BookingServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBookings_EquipmentId",
                table: "CustomerBookings",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBookings_FoodId",
                table: "CustomerBookings",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingServices_Quantity",
                table: "BookingServices",
                column: "Quantity");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingServices_Services_Quantity",
                table: "BookingServices",
                column: "Quantity",
                principalTable: "Services",
                principalColumn: "ServicesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBookings_Equipment_EquipmentId",
                table: "CustomerBookings",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBookings_Foods_FoodId",
                table: "CustomerBookings",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "FoodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingServices_Services_Quantity",
                table: "BookingServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBookings_Equipment_EquipmentId",
                table: "CustomerBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBookings_Foods_FoodId",
                table: "CustomerBookings");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBookings_EquipmentId",
                table: "CustomerBookings");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBookings_FoodId",
                table: "CustomerBookings");

            migrationBuilder.DropIndex(
                name: "IX_BookingServices_Quantity",
                table: "BookingServices");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "CustomerBookings");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "CustomerBookings");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "CustomerBookings");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BookingServices");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Services",
                type: "money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Services",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDays",
                table: "CustomerBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ServicesId",
                table: "BookingServices",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.CreateIndex(
                name: "IX_BookingServices_ServicesId",
                table: "BookingServices",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingServices_Services_ServicesId",
                table: "BookingServices",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "ServicesId");
        }
    }
}
