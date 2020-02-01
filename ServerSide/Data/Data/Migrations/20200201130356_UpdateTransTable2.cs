using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateTransTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FarmName",
                table: "Transactions");

            migrationBuilder.AddColumn<string>(
                name: "FarmOwnerName",
                table: "Transactions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FarmOwnerName",
                table: "Transactions");

            migrationBuilder.AddColumn<string>(
                name: "FarmName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
