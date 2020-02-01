using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Adding_LastTonPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LastTonPrice",
                table: "Reapers",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastTonPrice",
                table: "Reapers");
        }
    }
}
