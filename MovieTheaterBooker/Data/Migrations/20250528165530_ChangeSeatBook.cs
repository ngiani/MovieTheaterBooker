using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheaterBooker.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSeatBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatsBooking_Seats_SeatId",
                table: "SeatsBooking");

            migrationBuilder.DropIndex(
                name: "IX_SeatsBooking_SeatId",
                table: "SeatsBooking");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "SeatsBooking");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "SeatsBooking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SeatsBooking_SeatId",
                table: "SeatsBooking",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatsBooking_Seats_SeatId",
                table: "SeatsBooking",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
