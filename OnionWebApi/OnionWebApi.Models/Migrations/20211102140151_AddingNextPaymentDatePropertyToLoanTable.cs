using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnionWebApi.Models.Migrations
{
    public partial class AddingNextPaymentDatePropertyToLoanTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NextPaymentDate",
                table: "Loans",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextPaymentDate",
                table: "Loans");
        }
    }
}
