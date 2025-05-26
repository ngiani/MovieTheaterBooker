using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheaterBooker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AppDBContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheaterReleases_Movies_MovieId",
                table: "TheaterReleases");

            migrationBuilder.DropForeignKey(
                name: "FK_TheaterReleases_Theaters_ScreenId",
                table: "TheaterReleases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TheaterReleases",
                table: "TheaterReleases");

            migrationBuilder.RenameTable(
                name: "TheaterReleases",
                newName: "ScreenReleases");

            migrationBuilder.RenameIndex(
                name: "IX_TheaterReleases_ScreenId",
                table: "ScreenReleases",
                newName: "IX_ScreenReleases_ScreenId");

            migrationBuilder.RenameIndex(
                name: "IX_TheaterReleases_MovieId",
                table: "ScreenReleases",
                newName: "IX_ScreenReleases_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScreenReleases",
                table: "ScreenReleases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScreenReleases_Movies_MovieId",
                table: "ScreenReleases",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScreenReleases_Theaters_ScreenId",
                table: "ScreenReleases",
                column: "ScreenId",
                principalTable: "Theaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScreenReleases_Movies_MovieId",
                table: "ScreenReleases");

            migrationBuilder.DropForeignKey(
                name: "FK_ScreenReleases_Theaters_ScreenId",
                table: "ScreenReleases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScreenReleases",
                table: "ScreenReleases");

            migrationBuilder.RenameTable(
                name: "ScreenReleases",
                newName: "TheaterReleases");

            migrationBuilder.RenameIndex(
                name: "IX_ScreenReleases_ScreenId",
                table: "TheaterReleases",
                newName: "IX_TheaterReleases_ScreenId");

            migrationBuilder.RenameIndex(
                name: "IX_ScreenReleases_MovieId",
                table: "TheaterReleases",
                newName: "IX_TheaterReleases_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TheaterReleases",
                table: "TheaterReleases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TheaterReleases_Movies_MovieId",
                table: "TheaterReleases",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TheaterReleases_Theaters_ScreenId",
                table: "TheaterReleases",
                column: "ScreenId",
                principalTable: "Theaters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
