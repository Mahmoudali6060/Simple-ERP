using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Adding_Transaction_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    FarmId = table.Column<long>(nullable: false),
                    CategoryId = table.Column<long>(nullable: false),
                    DriverId = table.Column<long>(nullable: false),
                    SupplierQuantity = table.Column<long>(nullable: false),
                    Pardon = table.Column<long>(nullable: false),
                    TotalAfterPardon = table.Column<long>(nullable: false),
                    SupplierPrice = table.Column<long>(nullable: false),
                    SupplierAmount = table.Column<long>(nullable: false),
                    Nolon = table.Column<long>(nullable: false),
                    ReaperId = table.Column<long>(nullable: false),
                    ReapersPay = table.Column<long>(nullable: false),
                    SelectorId = table.Column<long>(nullable: false),
                    SelectorsPay = table.Column<long>(nullable: false),
                    FarmExpense = table.Column<long>(nullable: false),
                    SupplierTotal = table.Column<long>(nullable: false),
                    StationId = table.Column<long>(nullable: false),
                    CartNumber = table.Column<string>(nullable: true),
                    ClientQuantity = table.Column<long>(nullable: false),
                    ClientDiscount = table.Column<long>(nullable: false),
                    TotalAfterDiscount = table.Column<long>(nullable: false),
                    ClientPrice = table.Column<long>(nullable: false),
                    ClientTotal = table.Column<long>(nullable: false),
                    Sum = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
