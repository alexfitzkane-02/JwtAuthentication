using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JwtAuthentication.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class authmigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a12d6d0a-42d8-46ea-a0b8-2f31b652f159", "eba99433-6f9a-40a3-b537-04fd164991ea" },
                    { "e770e579-13a6-48ba-b8b5-039d477cdfb1", "eba99433-6f9a-40a3-b537-04fd164991ea" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a12d6d0a-42d8-46ea-a0b8-2f31b652f159", "eba99433-6f9a-40a3-b537-04fd164991ea" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e770e579-13a6-48ba-b8b5-039d477cdfb1", "eba99433-6f9a-40a3-b537-04fd164991ea" });
        }
    }
}
