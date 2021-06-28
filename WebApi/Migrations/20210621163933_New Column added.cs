using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi_Assign.Migrations
{
    public partial class NewColumnadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActionName",
                table: "MiddlewareClasses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ControllerName",
                table: "MiddlewareClasses",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Exception",
                table: "MiddlewareClasses",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionName",
                table: "MiddlewareClasses");

            migrationBuilder.DropColumn(
                name: "ControllerName",
                table: "MiddlewareClasses");

            migrationBuilder.DropColumn(
                name: "Exception",
                table: "MiddlewareClasses");
        }
    }
}
