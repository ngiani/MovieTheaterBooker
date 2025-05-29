using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheaterBooker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScreenReleases_Theaters_ScreenId",
                table: "ScreenReleases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Theaters",
                table: "Theaters");

            migrationBuilder.RenameTable(
                name: "Theaters",
                newName: "Screens");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Screens",
                table: "Screens",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ScreenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_Screens_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "Screens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_ScreenId",
                table: "Seat",
                column: "ScreenId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScreenReleases_Screens_ScreenId",
                table: "ScreenReleases",
                column: "ScreenId",
                principalTable: "Screens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScreenReleases_Screens_ScreenId",
                table: "ScreenReleases");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Screens",
                table: "Screens");

            migrationBuilder.RenameTable(
                name: "Screens",
                newName: "Theaters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Theaters",
                table: "Theaters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScreenReleases_Theaters_ScreenId",
                table: "ScreenReleases",
                column: "ScreenId",
                principalTable: "Theaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
