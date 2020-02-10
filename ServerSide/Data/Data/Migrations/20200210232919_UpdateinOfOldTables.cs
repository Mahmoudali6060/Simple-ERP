using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateinOfOldTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarPlate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ClientTotal",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "FarmOwnerName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ReaperHead",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StationOwnerName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Sum",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SupplierAmount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SupplierTotal",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TotalAfterDiscount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "TotalAfterPardon",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Outcomes");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Incomes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarPlate",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ClientTotal",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FarmOwnerName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReaperHead",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StationOwnerName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Sum",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SupplierAmount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SupplierTotal",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAfterDiscount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAfterPardon",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Outcomes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Incomes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
