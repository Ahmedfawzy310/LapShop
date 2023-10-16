using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripIoO.Data.Migrations
{
    /// <inheritdoc />
    public partial class admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Age], [CountryId], [FirstName], [GenderId], [LastName]) VALUES (N'05f4255c-9388-4f29-950d-d6cc0e85c99e', N'ahmed@gmail.com', N'AHMED@GMAIL.COM', N'ahmed@gmail.com', N'AHMED@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEORJspAWZp4xFPPQGGou0HYRFwo/aaV0pffCmL0t2qff91/TOTUyDnWTfGJcjF1RuQ==', N'NG7I743R2UG7VBON7JJQ3QEYCP2QKTUS', N'9840d61a-046c-46ad-8032-92e91bfa50d5', NULL, 0, 0, NULL, 1, 0, 0, 1, N'ahmed', 1, N'ahmed')\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUsers] WHERE Id='05f4255c-9388-4f29-950d-d6cc0e85c99e'");
        }
    }
}
