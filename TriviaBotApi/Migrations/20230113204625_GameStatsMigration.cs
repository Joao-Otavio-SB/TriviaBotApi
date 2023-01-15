using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriviaBotApi.Migrations
{
    /// <inheritdoc />
    public partial class GameStatsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameStats_Users_UserModelId",
                table: "GameStats");

            migrationBuilder.DropIndex(
                name: "IX_GameStats_UserModelId",
                table: "GameStats");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "GameStats");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "GameStats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GameStats_UserId",
                table: "GameStats",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameStats_Users_UserId",
                table: "GameStats",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameStats_Users_UserId",
                table: "GameStats");

            migrationBuilder.DropIndex(
                name: "IX_GameStats_UserId",
                table: "GameStats");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GameStats");

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "GameStats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameStats_UserModelId",
                table: "GameStats",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameStats_Users_UserModelId",
                table: "GameStats",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
