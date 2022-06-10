using Microsoft.EntityFrameworkCore.Migrations;

namespace Showsatron.Data.Migrations
{
    public partial class TheUpdatedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "AccountInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountInfos_Genres_GenreId",
                table: "AccountInfos");

            migrationBuilder.DropIndex(
                name: "IX_AccountInfos_GenreId",
                table: "AccountInfos");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "AccountInfos");
        }
    }
}
