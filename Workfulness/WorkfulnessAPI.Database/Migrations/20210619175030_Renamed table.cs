using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkfulnessAPI.Database.Migrations
{
    public partial class Renamedtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbTaskItem_ToDoLists_DbToDoListId",
                table: "DbTaskItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DbTaskItem",
                table: "DbTaskItem");

            migrationBuilder.RenameTable(
                name: "DbTaskItem",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_DbTaskItem_DbToDoListId",
                table: "Tasks",
                newName: "IX_Tasks_DbToDoListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_ToDoLists_DbToDoListId",
                table: "Tasks",
                column: "DbToDoListId",
                principalTable: "ToDoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_ToDoLists_DbToDoListId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "DbTaskItem");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_DbToDoListId",
                table: "DbTaskItem",
                newName: "IX_DbTaskItem_DbToDoListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbTaskItem",
                table: "DbTaskItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DbTaskItem_ToDoLists_DbToDoListId",
                table: "DbTaskItem",
                column: "DbToDoListId",
                principalTable: "ToDoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
