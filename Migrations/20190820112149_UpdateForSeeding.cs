using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Playground.Migrations
{
    public partial class UpdateForSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DepartmentId", "Email", "Firstname", "ManagerId", "PhoneNumber", "Surname", "Title" },
                values: new object[] { -2, -3, "tbean@company.com", "Tim", null, "+1237891011", "Bean", "Mr" });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "EmployeeId", "RoleId" },
                values: new object[] { -2, -2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumns: new[] { "EmployeeId", "RoleId" },
                keyValues: new object[] { -2, -2 });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: -2);
        }
    }
}
