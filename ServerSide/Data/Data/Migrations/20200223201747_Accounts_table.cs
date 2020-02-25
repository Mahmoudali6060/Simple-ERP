using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Accounts_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidDate",
                table: "Outcomes");

            migrationBuilder.DropColumn(
                name: "PaidUp",
                table: "Outcomes");

            migrationBuilder.DropColumn(
                name: "RecieptNumber",
                table: "Outcomes");

            migrationBuilder.DropColumn(
                name: "PaidDate",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "PaidUp",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "RecieptNumber",
                table: "Incomes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PaidDate",
                table: "Outcomes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaidUp",
                table: "Outcomes",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecieptNumber",
                table: "Outcomes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaidDate",
                table: "Incomes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaidUp",
                table: "Incomes",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecieptNumber",
                table: "Incomes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
