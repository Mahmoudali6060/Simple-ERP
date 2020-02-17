using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Adding_SelectorDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pay",
                table: "Selectors");

            migrationBuilder.DropColumn(
                name: "PayDate",
                table: "Selectors");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Selectors");

            migrationBuilder.DropColumn(
                name: "Withdraws",
                table: "Selectors");

            migrationBuilder.DropColumn(
                name: "WithdrawsDate",
                table: "Selectors");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Selectors",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeadName",
                table: "Selectors",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LastTonPrice",
                table: "Selectors",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "SelectorDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    PayDate = table.Column<DateTime>(nullable: false),
                    Pay = table.Column<decimal>(nullable: false),
                    WithdrawsDate = table.Column<DateTime>(nullable: true),
                    Withdraws = table.Column<decimal>(nullable: true),
                    Balance = table.Column<decimal>(nullable: true),
                    TransactionId = table.Column<long>(nullable: false),
                    SelectorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectorDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectorDetails_Selectors_SelectorId",
                        column: x => x.SelectorId,
                        principalTable: "Selectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectorDetails_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SelectorDetails_SelectorId",
                table: "SelectorDetails",
                column: "SelectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectorDetails_TransactionId",
                table: "SelectorDetails",
                column: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectorDetails");

            migrationBuilder.DropColumn(
                name: "HeadName",
                table: "Selectors");

            migrationBuilder.DropColumn(
                name: "LastTonPrice",
                table: "Selectors");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Selectors",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<decimal>(
                name: "Pay",
                table: "Selectors",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayDate",
                table: "Selectors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "TransactionId",
                table: "Selectors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "Withdraws",
                table: "Selectors",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WithdrawsDate",
                table: "Selectors",
                type: "datetime2",
                nullable: true);
        }
    }
}
