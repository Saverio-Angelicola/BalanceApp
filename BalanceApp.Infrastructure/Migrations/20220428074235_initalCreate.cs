using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BalanceApp.Infrastructure.Migrations
{
    public partial class initalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Firstname = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    UserPassword = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: false),
                    LastUpdate = table.Column<string>(type: "text", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BodyData",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    FatMassRate = table.Column<double>(type: "double precision", nullable: false),
                    WaterRate = table.Column<double>(type: "double precision", nullable: false),
                    MuscleRate = table.Column<double>(type: "double precision", nullable: false),
                    BoneRate = table.Column<double>(type: "double precision", nullable: false),
                    HeartBeat = table.Column<double>(type: "double precision", nullable: false),
                    BodyMassIndex = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyData", x => new { x.UserId, x.Id });
                    table.ForeignKey(
                        name: "FK_BodyData_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyData");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
