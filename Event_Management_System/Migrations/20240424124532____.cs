using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class ___ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingServices_Services_Quantity",
                table: "BookingServices");

            migrationBuilder.DropIndex(
                name: "IX_BookingServices_Quantity",
                table: "BookingServices");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingServices_Services_ServicesId",
                table: "BookingServices");

            migrationBuilder.DropIndex(
                name: "IX_BookingServices_ServicesId",
                table: "BookingServices");

            migrationBuilder.AlterColumn<decimal>(
                name: "ServicesId",
                table: "BookingServices",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
        }
    }
}
