using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi_Assign.Migrations
{
    public partial class MiddlewareMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MiddlewareClasses",
                columns: table => new
                {
                    LogId = table.Column<int>(maxLength: 20, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogGUID = table.Column<string>(maxLength: 100, nullable: false),
                    Request = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiddlewareClasses", x => x.LogId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiddlewareClasses_LogId",
                table: "MiddlewareClasses",
                column: "LogId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiddlewareClasses");
        }
    }
}
