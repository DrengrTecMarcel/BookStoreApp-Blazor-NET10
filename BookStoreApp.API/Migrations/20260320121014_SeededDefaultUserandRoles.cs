using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUserandRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cb7b1fd1-881c-4959-a659-60717a771f8b", "c7f7e77e-5434-4696-a466-af315f6a97c8", "User", "USER" },
                    { "e8f2a8db-fd51-4a5d-8bcb-d7cf56baef15", "aa375f59-4955-410e-8050-e89640b8e028", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6e9457dc-383e-4090-9154-f813e89f8192", 0, "8627eb51-0bcc-4ffb-85d9-163a77cbdef9", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEPj/CWP3pDaKrpDtVpT7e0XyDy3kvXDiEeKfUXz/JYPoItNCIPHQytUPJgROptHSJA==", null, false, "6cbc7851-0e1c-44f3-90fe-135fe384a63d", false, "user@bookstore.com" },
                    { "dcf2b06f-6b0b-4a29-b647-f653b53ef284", 0, "0c553440-ea36-4df0-9928-8570caa52d3f", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEBOU0vVE9P1UHMiNJeuitcMkp24swy8cyfK7l7qRlq2iznfsov/sXbNZ2kCsqoc1+Q==", null, false, "8979c013-0841-4d9f-8757-5c17de68aa7a", false, "admin@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cb7b1fd1-881c-4959-a659-60717a771f8b", "6e9457dc-383e-4090-9154-f813e89f8192" },
                    { "e8f2a8db-fd51-4a5d-8bcb-d7cf56baef15", "dcf2b06f-6b0b-4a29-b647-f653b53ef284" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cb7b1fd1-881c-4959-a659-60717a771f8b", "6e9457dc-383e-4090-9154-f813e89f8192" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e8f2a8db-fd51-4a5d-8bcb-d7cf56baef15", "dcf2b06f-6b0b-4a29-b647-f653b53ef284" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb7b1fd1-881c-4959-a659-60717a771f8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8f2a8db-fd51-4a5d-8bcb-d7cf56baef15");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e9457dc-383e-4090-9154-f813e89f8192");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dcf2b06f-6b0b-4a29-b647-f653b53ef284");
        }
    }
}
