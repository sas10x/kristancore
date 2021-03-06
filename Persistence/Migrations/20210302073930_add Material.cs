using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Article = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Uom = table.Column<string>(nullable: true),
                    Gtin = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Manager = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
