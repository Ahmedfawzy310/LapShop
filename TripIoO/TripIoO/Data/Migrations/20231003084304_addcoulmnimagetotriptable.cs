using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripIoO.Data.Migrations
{
    /// <inheritdoc />
    public partial class addcoulmnimagetotriptable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndIn",
                table: "TbTrips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartIn",
                table: "TbTrips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndIn",
                table: "TbTrips");

            migrationBuilder.DropColumn(
                name: "StartIn",
                table: "TbTrips");
        }
    }
}
