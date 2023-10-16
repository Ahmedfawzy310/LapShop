using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripIoO.Data.Migrations
{
    /// <inheritdoc />
    public partial class adminrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into AspNetUserRoles (UserId,RoleId) select '05f4255c-9388-4f29-950d-d6cc0e85c99e', Id from AspNetRoles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from AspNetUserRoles where UserId='05f4255c-9388-4f29-950d-d6cc0e85c99e'");
        }
    }
}
