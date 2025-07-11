using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieTheaterBooker.Data.Migrations
{
    /// <inheritdoc />
    public partial class ass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59756ceb-3b8c-4467-9af5-0fed41b388cc", null, "Admin", "ADMIN" },
                    { "b6aed041-08b2-4530-a41c-ccdaecffeb5a", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ba1fa5bc-c23c-4c31-87cd-f173d9cfba3d", 0, "276698d7-6cf1-4026-a6cb-279ef1e3aee0", new DateOnly(12, 12, 11), "admina@localhost.com", true, "Default", "Admin", false, null, "ADMINA@LOCALHOST.COM", "ADMINA@LOCALHOST.COM", "AQAAAAIAAYagAAAAEESKK/BRB8rCjQDQxEN3IixF3i4UqXaIgxZDXA6Nr9/5OpOpj2Isbabf2sle0bIFdA==", null, false, "0ae7d5c0-d61a-47a0-b239-8b72cce6779b", false, "admina@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "59756ceb-3b8c-4467-9af5-0fed41b388cc", "ba1fa5bc-c23c-4c31-87cd-f173d9cfba3d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6aed041-08b2-4530-a41c-ccdaecffeb5a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "59756ceb-3b8c-4467-9af5-0fed41b388cc", "ba1fa5bc-c23c-4c31-87cd-f173d9cfba3d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59756ceb-3b8c-4467-9af5-0fed41b388cc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba1fa5bc-c23c-4c31-87cd-f173d9cfba3d");
        }
    }
}
