using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addactivitiesmb51zva05n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivitiesMb51",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(nullable: true),
                    Article = table.Column<string>(nullable: true),
                    Document = table.Column<string>(nullable: true),
                    Mb51Id = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    GtrStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesMb51", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivitiesMb51_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivitiesMb51_Mb51_Mb51Id",
                        column: x => x.Mb51Id,
                        principalTable: "Mb51",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivitiesZva05n",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(nullable: true),
                    Article = table.Column<string>(nullable: true),
                    SO = table.Column<string>(nullable: true),
                    Zva05nId = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    GtrStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitiesZva05n", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivitiesZva05n_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivitiesZva05n_Zva05n_Zva05nId",
                        column: x => x.Zva05nId,
                        principalTable: "Zva05n",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesMb51_AppUserId",
                table: "ActivitiesMb51",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesMb51_Mb51Id",
                table: "ActivitiesMb51",
                column: "Mb51Id");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesZva05n_AppUserId",
                table: "ActivitiesZva05n",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesZva05n_Zva05nId",
                table: "ActivitiesZva05n",
                column: "Zva05nId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivitiesMb51");

            migrationBuilder.DropTable(
                name: "ActivitiesZva05n");
        }
    }
}
