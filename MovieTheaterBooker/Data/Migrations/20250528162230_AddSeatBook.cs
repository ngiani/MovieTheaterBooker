using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheaterBooker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeatBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeatsBooking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    ScreenReleaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatsBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatsBooking_ScreenReleases_ScreenReleaseId",
                        column: x => x.ScreenReleaseId,
                        principalTable: "ScreenReleases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeatsBooking_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeatsBooking_ScreenReleaseId",
                table: "SeatsBooking",
                column: "ScreenReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatsBooking_SeatId",
                table: "SeatsBooking",
                column: "SeatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatsBooking");
        }
    }
}
