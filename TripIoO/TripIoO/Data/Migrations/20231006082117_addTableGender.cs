using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripIoO.Data.Migrations
{
    /// <inheritdoc />
    public partial class addTableGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TbGender_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TbGender");

            migrationBuilder.CreateTable(
                name: "TbGenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbGenders", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TbGenders_GenderId",
                table: "AspNetUsers",
                column: "GenderId",
                principalTable: "TbGenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TbGenders_GenderId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TbGenders");

            migrationBuilder.CreateTable(
                name: "TbGender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbGender", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TbGender_GenderId",
                table: "AspNetUsers",
                column: "GenderId",
                principalTable: "TbGender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
