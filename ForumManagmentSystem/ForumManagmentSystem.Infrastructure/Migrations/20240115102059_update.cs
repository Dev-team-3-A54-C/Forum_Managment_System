using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumManagmentSystem.Infrastructure.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Users_UserId",
                table: "Replies");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Replies",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_UserId",
                table: "Replies",
                newName: "IX_Replies_CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Users_CreatedBy",
                table: "Replies",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Users_CreatedBy",
                table: "Replies");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Replies",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_CreatedBy",
                table: "Replies",
                newName: "IX_Replies_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Users_UserId",
                table: "Replies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
