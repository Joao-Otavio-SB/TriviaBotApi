using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TriviaBotApi.Migrations
{
    /// <inheritdoc />
    public partial class UserGameStatsRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneralRecord",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Record",
                table: "GameStats",
                newName: "GeneralRecord");

            migrationBuilder.AddColumn<int>(
                name: "CategoryRecord",
                table: "GameStats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryRecord",
                table: "GameStats");

            migrationBuilder.RenameColumn(
                name: "GeneralRecord",
                table: "GameStats",
                newName: "Record");

            migrationBuilder.AddColumn<int>(
                name: "GeneralRecord",
                table: "Users",
                type: "int",
                nullable: true);
        }
    }
}
