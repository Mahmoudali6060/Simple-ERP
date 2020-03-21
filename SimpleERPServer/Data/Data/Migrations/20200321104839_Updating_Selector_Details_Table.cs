using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Updating_Selector_Details_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "SelectorDetails");

            migrationBuilder.DropColumn(
                name: "Pay",
                table: "SelectorDetails");

            migrationBuilder.DropColumn(
                name: "PayDate",
                table: "SelectorDetails");

            migrationBuilder.DropColumn(
                name: "Withdraws",
                table: "SelectorDetails");

            migrationBuilder.DropColumn(
                name: "WithdrawsDate",
                table: "SelectorDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "SelectorDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Pay",
                table: "SelectorDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayDate",
                table: "SelectorDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Withdraws",
                table: "SelectorDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WithdrawsDate",
                table: "SelectorDetails",
                type: "datetime2",
                nullable: true);
        }
    }
}
