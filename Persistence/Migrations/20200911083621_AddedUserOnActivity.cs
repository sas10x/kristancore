using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedUserOnActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_AuthorId",
                table: "Activities",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AspNetUsers_AuthorId",
                table: "Activities",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AspNetUsers_AuthorId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_AuthorId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Activities");
        }
    }
}
