using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Adding_AccountNameAr_Col : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountNameAr",
                table: "Safes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNameAr",
                table: "Safes");
        }
    }
}
