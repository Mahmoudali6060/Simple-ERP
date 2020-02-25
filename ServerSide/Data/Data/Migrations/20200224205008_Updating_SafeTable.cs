using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Updating_SafeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Safes_AccountTrees_AccountTreeId",
                table: "Safes");

            migrationBuilder.DropIndex(
                name: "IX_Safes_AccountTreeId",
                table: "Safes");

            migrationBuilder.DropColumn(
                name: "AccountTreeId",
                table: "Safes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountTreeId",
                table: "Safes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Safes_AccountTreeId",
                table: "Safes",
                column: "AccountTreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Safes_AccountTrees_AccountTreeId",
                table: "Safes",
                column: "AccountTreeId",
                principalTable: "AccountTrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
