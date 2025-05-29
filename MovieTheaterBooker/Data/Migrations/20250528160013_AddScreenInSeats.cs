using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheaterBooker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddScreenInSeats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Screens_ScreenId",
                table: "Seat");

            migrationBuilder.AlterColumn<int>(
                name: "ScreenId",
                table: "Seat",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Screens_ScreenId",
                table: "Seat",
                column: "ScreenId",
                principalTable: "Screens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Screens_ScreenId",
                table: "Seat");

            migrationBuilder.AlterColumn<int>(
                name: "ScreenId",
                table: "Seat",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Screens_ScreenId",
                table: "Seat",
                column: "ScreenId",
                principalTable: "Screens",
                principalColumn: "Id");
        }
    }
}
