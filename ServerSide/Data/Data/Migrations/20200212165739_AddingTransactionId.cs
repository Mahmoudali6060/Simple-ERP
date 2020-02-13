using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddingTransactionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TransactionId",
                table: "Transfers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TransactionId",
                table: "Outcomes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TransactionId",
                table: "Incomes",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Outcomes");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Incomes");
        }
    }
}
