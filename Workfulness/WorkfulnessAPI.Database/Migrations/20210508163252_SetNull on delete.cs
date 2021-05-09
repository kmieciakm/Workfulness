using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkfulnessAPI.Database.Migrations
{
    public partial class SetNullondelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_PlaylistsCategories_CategoryId",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Playlists_DbPlaylistId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_CategoryId",
                table: "Playlists");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_CategoryId",
                table: "Playlists",
                column: "CategoryId",
                unique: true,
                filter: "[CategoryId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_PlaylistsCategories_CategoryId",
                table: "Playlists",
                column: "CategoryId",
                principalTable: "PlaylistsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Playlists_DbPlaylistId",
                table: "Songs",
                column: "DbPlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_PlaylistsCategories_CategoryId",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Playlists_DbPlaylistId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_CategoryId",
                table: "Playlists");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_CategoryId",
                table: "Playlists",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_PlaylistsCategories_CategoryId",
                table: "Playlists",
                column: "CategoryId",
                principalTable: "PlaylistsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Playlists_DbPlaylistId",
                table: "Songs",
                column: "DbPlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
