using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Contexts.Data.Migrations
{
    public partial class Balance_TotalIncomes_totalSpendings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalIncomesResult",
                table: "Balances",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalSpendingsResult",
                table: "Balances",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalIncomesResult",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "TotalSpendingsResult",
                table: "Balances");
        }
    }
}
