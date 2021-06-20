using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkfulnessAPI.Database.Migrations
{
    public partial class Addedprivateusersplaylist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DbUserId",
                table: "Playlists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_DbUserId",
                table: "Playlists",
                column: "DbUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_AspNetUsers_DbUserId",
                table: "Playlists",
                column: "DbUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_AspNetUsers_DbUserId",
                table: "Playlists");

            migrationBuilder.DropIndex(
                name: "IX_Playlists_DbUserId",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "DbUserId",
                table: "Playlists");
        }
    }
}
