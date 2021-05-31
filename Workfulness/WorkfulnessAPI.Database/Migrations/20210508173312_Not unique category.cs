using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkfulnessAPI.Database.Migrations
{
    public partial class Notuniquecategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Playlists_CategoryId",
                table: "Playlists");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_CategoryId",
                table: "Playlists",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Playlists_CategoryId",
                table: "Playlists");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_CategoryId",
                table: "Playlists",
                column: "CategoryId",
                unique: true,
                filter: "[CategoryId] IS NOT NULL");
        }
    }
}
