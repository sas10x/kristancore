using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addmovement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document = table.Column<string>(nullable: true),
                    Article = table.Column<string>(nullable: true),
                    BUn = table.Column<string>(nullable: true),
                    Quantity = table.Column<string>(nullable: true),
                    MvT = table.Column<string>(nullable: true),
                    Site = table.Column<string>(nullable: true),
                    SLoc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zmpq25b",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Article = table.Column<string>(nullable: true),
                    Gtin = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BUn = table.Column<string>(nullable: true),
                    Site = table.Column<string>(nullable: true),
                    SLoc = table.Column<string>(nullable: true),
                    Unrestricted = table.Column<int>(nullable: false),
                    Confirm = table.Column<int>(nullable: false),
                    ATP = table.Column<int>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zmpq25b", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movements");

            migrationBuilder.DropTable(
                name: "Zmpq25b");
        }
    }
}
