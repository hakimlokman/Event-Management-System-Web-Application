using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class lokman : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillTables_CustomerBookings_CustomerBookingId",
                table: "BillTables");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerBookingId",
                table: "BillTables",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BillTables_CustomerBookings_CustomerBookingId",
                table: "BillTables",
                column: "CustomerBookingId",
                principalTable: "CustomerBookings",
                principalColumn: "CustomerBookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillTables_CustomerBookings_CustomerBookingId",
                table: "BillTables");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerBookingId",
                table: "BillTables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BillTables_CustomerBookings_CustomerBookingId",
                table: "BillTables",
                column: "CustomerBookingId",
                principalTable: "CustomerBookings",
                principalColumn: "CustomerBookingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
