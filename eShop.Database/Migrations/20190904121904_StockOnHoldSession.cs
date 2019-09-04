using Microsoft.EntityFrameworkCore.Migrations;

namespace eShop.Database.Migrations
{
    public partial class StockOnHoldSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Session",
                table: "StockOnHolds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Session",
                table: "StockOnHolds");
        }
    }
}
