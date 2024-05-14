using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class Script__ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServicesId",
                table: "CustomerBookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBookings_ServicesId",
                table: "CustomerBookings",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBookings_Services_ServicesId",
                table: "CustomerBookings",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "ServicesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBookings_Services_ServicesId",
                table: "CustomerBookings");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBookings_ServicesId",
                table: "CustomerBookings");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "CustomerBookings");
        }
    }
}
