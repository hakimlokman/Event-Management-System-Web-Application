﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class venuephoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venues_VenueTypes_VenueTypeId",
                table: "Venues");

            migrationBuilder.DropTable(
                name: "VenueTypes");

            migrationBuilder.DropIndex(
                name: "IX_Venues_VenueTypeId",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "VenueTypeId",
                table: "Venues");

            migrationBuilder.RenameColumn(
                name: "VenuePhoto",
                table: "Venues",
                newName: "VenueType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VenueType",
                table: "Venues",
                newName: "VenuePhoto");

            migrationBuilder.AddColumn<int>(
                name: "VenueTypeId",
                table: "Venues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VenueTypes",
                columns: table => new
                {
                    VenueTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueTypes", x => x.VenueTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Venues_VenueTypeId",
                table: "Venues",
                column: "VenueTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venues_VenueTypes_VenueTypeId",
                table: "Venues",
                column: "VenueTypeId",
                principalTable: "VenueTypes",
                principalColumn: "VenueTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
