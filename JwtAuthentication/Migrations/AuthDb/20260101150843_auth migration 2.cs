using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtAuthentication.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class authmigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eba99433-6f9a-40a3-b537-04fd164991ea", 0, "2d7a8921-a61b-4a42-a7af-a8ac12e89b31", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEPhkEVLlnz/KgclF1MEKvjZMKxnmNwGhSuxEuRDNeo4HJSHijhI+QaKDzxVTmHBsAw==", null, false, "4063c969-91f5-4a50-8cf0-da30d29457de", false, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eba99433-6f9a-40a3-b537-04fd164991ea");
        }
    }
}
