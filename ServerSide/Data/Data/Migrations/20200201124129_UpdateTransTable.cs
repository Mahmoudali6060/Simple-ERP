using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateTransTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarPlate",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FarmName",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReaperHead",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "StationOwnerName",
                table: "Transactions",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarPlate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "FarmName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ReaperHead",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StationOwnerName",
                table: "Transactions");
        }
    }
}
