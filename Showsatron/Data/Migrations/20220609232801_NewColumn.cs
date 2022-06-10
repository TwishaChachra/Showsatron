using Microsoft.EntityFrameworkCore.Migrations;

namespace Showsatron.Data.Migrations
{
    public partial class NewColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountInfos_Genres_GenreId",
                table: "AccountInfos");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "AccountInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "AccountInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountInfos_Genres_GenreId",
                table: "AccountInfos",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
