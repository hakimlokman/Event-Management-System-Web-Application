using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class addBillTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillTables",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalEquipmentBill = table.Column<double>(type: "float", nullable: false),
                    totalFoodBill = table.Column<double>(type: "float", nullable: false),
                    totalServicesBill = table.Column<double>(type: "float", nullable: false),
                    GrandTotal = table.Column<double>(type: "float", nullable: false),
                    AdvancePayment = table.Column<double>(type: "float", nullable: false),
                    DuePayment = table.Column<double>(type: "float", nullable: false),
                    CustomerBookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillTables", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_BillTables_CustomerBookings_CustomerBookingId",
                        column: x => x.CustomerBookingId,
                        principalTable: "CustomerBookings",
                        principalColumn: "CustomerBookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillTables_CustomerBookingId",
                table: "BillTables",
                column: "CustomerBookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillTables");
        }
    }
}
