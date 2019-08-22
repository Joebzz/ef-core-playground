using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Playground.Migrations
{
    public partial class AddedSocialSecurityNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SocialSecurityNumber",
                table: "Employees",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: -3,
                column: "SocialSecurityNumber",
                value: "P1234567892");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: -2,
                column: "SocialSecurityNumber",
                value: "P1234567891");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: -1,
                column: "SocialSecurityNumber",
                value: "P1234567890");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SocialSecurityNumber",
                table: "Employees");
        }
    }
}
