using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUsersandRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11a9e2b7-8bb5-4dce-be64-49e3d32e4024", "4373e225-e2bd-4c9b-b4fe-60bf2299f483", "User", "USER" },
                    { "8aaa353c-cdb7-4b0f-a0f5-945e25261d74", "c9e5ceb2-6cc9-43df-9359-3e193c9906b0", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6e965686-96a0-4c4b-9a01-326a834d4030", 0, "bca53fa1-6b96-4a9e-bf77-7c3eb44b01cd", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAIAAYagAAAAECfGXpzDl6kTSCWzgNTz5z+yA8JQuo0ls9HKQv0w4MhuigunD19d2+knNIXhNyoc4w==", null, false, "56a2a0c4-469c-4c6f-80ef-9e0aef14f93f", false, "user@bookstore.com" },
                    { "7da4e12e-a20f-4b6b-93f0-b6277af03c0f", 0, "ee87fe9c-83df-4475-bb13-c0ecd3d22f52", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEDqM1YDPl3DN5BGvJAO0I9GqjxK+LN4QhPonechGcEMH+cXaN9I85KbDkQZpq7qXeg==", null, false, "17b26eea-4985-45b7-bc68-485b8561a519", false, "admin@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "11a9e2b7-8bb5-4dce-be64-49e3d32e4024", "6e965686-96a0-4c4b-9a01-326a834d4030" },
                    { "8aaa353c-cdb7-4b0f-a0f5-945e25261d74", "7da4e12e-a20f-4b6b-93f0-b6277af03c0f" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "11a9e2b7-8bb5-4dce-be64-49e3d32e4024", "6e965686-96a0-4c4b-9a01-326a834d4030" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8aaa353c-cdb7-4b0f-a0f5-945e25261d74", "7da4e12e-a20f-4b6b-93f0-b6277af03c0f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11a9e2b7-8bb5-4dce-be64-49e3d32e4024");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aaa353c-cdb7-4b0f-a0f5-945e25261d74");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e965686-96a0-4c4b-9a01-326a834d4030");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7da4e12e-a20f-4b6b-93f0-b6277af03c0f");
        }
    }
}
