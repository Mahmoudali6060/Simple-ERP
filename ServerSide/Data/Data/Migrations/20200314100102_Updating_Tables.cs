using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Updating_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "Withdraws",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "PaidDate",
                table: "ReaperDetails");

            migrationBuilder.DropColumn(
                name: "PaidUp",
                table: "ReaperDetails");

            migrationBuilder.DropColumn(
                name: "TonPrice",
                table: "ReaperDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "SelectorDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HeadName",
                table: "SelectorDetails",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "SelectorDetails",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "SelectorDetails",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "HeadName",
                table: "ReaperDetails",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ReaperDetails",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "SelectorDetails");

            migrationBuilder.DropColumn(
                name: "HeadName",
                table: "SelectorDetails");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "SelectorDetails");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "SelectorDetails");

            migrationBuilder.DropColumn(
                name: "HeadName",
                table: "ReaperDetails");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ReaperDetails");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Transfers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Withdraws",
                table: "Transfers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaidDate",
                table: "ReaperDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaidUp",
                table: "ReaperDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TonPrice",
                table: "ReaperDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
