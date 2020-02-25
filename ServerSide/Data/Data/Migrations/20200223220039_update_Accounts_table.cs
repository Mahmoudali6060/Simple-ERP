using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class update_Accounts_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Safes");

            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "Safes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "DriverAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    SafeId = table.Column<long>(nullable: false),
                    PaidUp = table.Column<decimal>(nullable: true),
                    PaidDate = table.Column<DateTime>(nullable: true),
                    RecieptNumber = table.Column<string>(nullable: true),
                    DriverId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DriverAccounts_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    SafeId = table.Column<long>(nullable: false),
                    PaidUp = table.Column<decimal>(nullable: true),
                    PaidDate = table.Column<DateTime>(nullable: true),
                    RecieptNumber = table.Column<string>(nullable: true),
                    FarmerId = table.Column<long>(nullable: false),
                    FarmId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmAccounts_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReaperAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    SafeId = table.Column<long>(nullable: false),
                    PaidUp = table.Column<decimal>(nullable: true),
                    PaidDate = table.Column<DateTime>(nullable: true),
                    RecieptNumber = table.Column<string>(nullable: true),
                    ReaperId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReaperAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReaperAccounts_Reapers_ReaperId",
                        column: x => x.ReaperId,
                        principalTable: "Reapers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectorAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    SafeId = table.Column<long>(nullable: false),
                    PaidUp = table.Column<decimal>(nullable: true),
                    PaidDate = table.Column<DateTime>(nullable: true),
                    RecieptNumber = table.Column<string>(nullable: true),
                    SelectorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectorAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectorAccounts_Selectors_SelectorId",
                        column: x => x.SelectorId,
                        principalTable: "Selectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StationAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    SafeId = table.Column<long>(nullable: false),
                    PaidUp = table.Column<decimal>(nullable: true),
                    PaidDate = table.Column<DateTime>(nullable: true),
                    RecieptNumber = table.Column<string>(nullable: true),
                    StationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StationAccounts_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverAccounts_DriverId",
                table: "DriverAccounts",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmAccounts_FarmId",
                table: "FarmAccounts",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_ReaperAccounts_ReaperId",
                table: "ReaperAccounts",
                column: "ReaperId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectorAccounts_SelectorId",
                table: "SelectorAccounts",
                column: "SelectorId");

            migrationBuilder.CreateIndex(
                name: "IX_StationAccounts_StationId",
                table: "StationAccounts",
                column: "StationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverAccounts");

            migrationBuilder.DropTable(
                name: "FarmAccounts");

            migrationBuilder.DropTable(
                name: "ReaperAccounts");

            migrationBuilder.DropTable(
                name: "SelectorAccounts");

            migrationBuilder.DropTable(
                name: "StationAccounts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Safes");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Safes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
