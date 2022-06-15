using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BalanceApp.Infrastructure.Migrations
{
    public partial class removeHeartBeat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeartBeat",
                table: "BodyData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "HeartBeat",
                table: "BodyData",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
