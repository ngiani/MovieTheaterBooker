using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheaterBooker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba1fa5bc-c23c-4c31-87cd-f173d9cfba3d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5658c70-ea6e-4ef9-9782-4ab2f9484927", "AQAAAAIAAYagAAAAEEQ5dqbal7cXAkQ+K254pBBw2vt4ChMroYAKs0wre0b92QuBQZ8vTNKRiqUjauyZDQ==", "602dc3d1-de7d-423c-bbd1-8a05120627f5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Movies");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba1fa5bc-c23c-4c31-87cd-f173d9cfba3d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "276698d7-6cf1-4026-a6cb-279ef1e3aee0", "AQAAAAIAAYagAAAAEESKK/BRB8rCjQDQxEN3IixF3i4UqXaIgxZDXA6Nr9/5OpOpj2Isbabf2sle0bIFdA==", "0ae7d5c0-d61a-47a0-b239-8b72cce6779b" });
        }
    }
}
