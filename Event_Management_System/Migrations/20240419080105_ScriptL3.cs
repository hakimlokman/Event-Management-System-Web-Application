using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class ScriptL3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VenuePhoto1",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "VenuePhoto2",
                table: "Venues");

            migrationBuilder.RenameColumn(
                name: "VenuePhoto3",
                table: "Venues",
                newName: "VenuePhoto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VenuePhoto",
                table: "Venues",
                newName: "VenuePhoto3");

            migrationBuilder.AddColumn<string>(
                name: "VenuePhoto1",
                table: "Venues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VenuePhoto2",
                table: "Venues",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
