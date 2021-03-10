using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addmb51zva05n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GtrStatus",
                table: "Zmpq25b",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mb51",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document = table.Column<string>(nullable: true),
                    Article = table.Column<string>(nullable: true),
                    BUn = table.Column<string>(nullable: true),
                    Quantity = table.Column<string>(nullable: true),
                    MvT = table.Column<string>(nullable: true),
                    Site = table.Column<string>(nullable: true),
                    SLoc = table.Column<string>(nullable: true),
                    GtrStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mb51", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zva05n",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryStatus = table.Column<string>(nullable: true),
                    SO = table.Column<string>(nullable: true),
                    Site = table.Column<string>(nullable: true),
                    SLoc = table.Column<string>(nullable: true),
                    ShpTyp = table.Column<string>(nullable: true),
                    Docdate = table.Column<string>(nullable: true),
                    ItemNum = table.Column<string>(nullable: true),
                    UoM = table.Column<string>(nullable: true),
                    OrdQty = table.Column<int>(nullable: false),
                    ConfQty = table.Column<int>(nullable: false),
                    PgiQty = table.Column<int>(nullable: false),
                    QtyToDeliv = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    NetAmt = table.Column<decimal>(nullable: false),
                    NetTax = table.Column<decimal>(nullable: false),
                    InvoiceAmt = table.Column<decimal>(nullable: false),
                    TotalPending = table.Column<decimal>(nullable: false),
                    SalesOrg = table.Column<string>(nullable: true),
                    SType = table.Column<string>(nullable: true),
                    Salesman = table.Column<string>(nullable: true),
                    CustCode = table.Column<string>(nullable: true),
                    SalGrp = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Entrytime = table.Column<string>(nullable: true),
                    CCodeToBeBilled = table.Column<string>(nullable: true),
                    DistChan = table.Column<string>(nullable: true),
                    GtrStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zva05n", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mb51");

            migrationBuilder.DropTable(
                name: "Zva05n");

            migrationBuilder.DropColumn(
                name: "GtrStatus",
                table: "Zmpq25b");
        }
    }
}
