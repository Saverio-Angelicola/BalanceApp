using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BalanceApp.Infrastructure.Migrations
{
    public partial class addHeightColumnOnUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "users",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "users");
        }
    }
}
