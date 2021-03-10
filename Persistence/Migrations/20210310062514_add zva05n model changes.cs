using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addzva05nmodelchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrdQty",
                table: "Zva05n");

            migrationBuilder.AddColumn<string>(
                name: "ArtNum",
                table: "Zva05n",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleDescription",
                table: "Zva05n",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderedQty",
                table: "Zva05n",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtNum",
                table: "Zva05n");

            migrationBuilder.DropColumn(
                name: "ArticleDescription",
                table: "Zva05n");

            migrationBuilder.DropColumn(
                name: "OrderedQty",
                table: "Zva05n");

            migrationBuilder.AddColumn<int>(
                name: "OrdQty",
                table: "Zva05n",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
