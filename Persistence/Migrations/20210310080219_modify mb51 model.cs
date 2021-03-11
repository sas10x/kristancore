using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class modifymb51model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Document",
                table: "Mb51");

            migrationBuilder.AddColumn<string>(
                name: "ArtDoc",
                table: "Mb51",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleDescription",
                table: "Mb51",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "Mb51",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocDate",
                table: "Mb51",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryDate",
                table: "Mb51",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MvtTypeText",
                table: "Mb51",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name1",
                table: "Mb51",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PstngDate",
                table: "Mb51",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Mb51",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Mb51",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtDoc",
                table: "Mb51");

            migrationBuilder.DropColumn(
                name: "ArticleDescription",
                table: "Mb51");

            migrationBuilder.DropColumn(
                name: "Customer",
                table: "Mb51");

            migrationBuilder.DropColumn(
                name: "DocDate",
                table: "Mb51");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "Mb51");

            migrationBuilder.DropColumn(
                name: "MvtTypeText",
                table: "Mb51");

            migrationBuilder.DropColumn(
                name: "Name1",
                table: "Mb51");

            migrationBuilder.DropColumn(
                name: "PstngDate",
                table: "Mb51");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Mb51");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Mb51");

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "Mb51",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
