using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheaterBooker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedRefactorRow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Seats",
                newName: "Row");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Row",
                table: "Seats",
                newName: "Name");
        }
    }
}
