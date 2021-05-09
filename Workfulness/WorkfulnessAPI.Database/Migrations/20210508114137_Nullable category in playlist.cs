using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkfulnessAPI.Database.Migrations
{
    public partial class Nullablecategoryinplaylist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_PlaylistsCategories_CategoryId",
                table: "Playlists");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Playlists",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_PlaylistsCategories_CategoryId",
                table: "Playlists",
                column: "CategoryId",
                principalTable: "PlaylistsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_PlaylistsCategories_CategoryId",
                table: "Playlists");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Playlists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_PlaylistsCategories_CategoryId",
                table: "Playlists",
                column: "CategoryId",
                principalTable: "PlaylistsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
