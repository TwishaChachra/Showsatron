using Microsoft.EntityFrameworkCore.Migrations;

namespace Showsatron.Data.Migrations
{
    public partial class Try : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountInfos_Genres_GenreId",
                table: "AccountInfos");

            migrationBuilder.DropIndex(
                name: "IX_AccountInfos_GenreId",
                table: "AccountInfos");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "AccountInfos");

            migrationBuilder.DropColumn(
                name: "ProfileName",
                table: "AccountInfos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Platforms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "AccountInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProfileName",
                table: "AccountInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountInfos_GenreId",
                table: "AccountInfos",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountInfos_Genres_GenreId",
                table: "AccountInfos",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
