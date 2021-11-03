using Microsoft.EntityFrameworkCore.Migrations;

namespace OnionWebApi.Models.Migrations
{
    public partial class AddingPaymentsMadeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentsMade",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentsMade",
                table: "Loans");
        }
    }
}
