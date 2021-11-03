using Microsoft.EntityFrameworkCore.Migrations;

namespace OnionWebApi.Models.Migrations
{
    public partial class AddingNulleableToPaymentsMadePropertyOnLoanTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PaymentsMade",
                table: "Loans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PaymentsMade",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
