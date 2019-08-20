using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Playground.Migrations
{
    public partial class AddedEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "EmployeeId", "RoleId" },
                values: new object[] { -2, -1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DepartmentId", "Email", "Firstname", "ManagerId", "PhoneNumber", "Surname", "Title" },
                values: new object[] { -3, -3, "jblack@company.com", "Jack", -2, "+1237891013", "Black", "Mr" });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "EmployeeId", "RoleId" },
                values: new object[] { -3, -2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumns: new[] { "EmployeeId", "RoleId" },
                keyValues: new object[] { -3, -2 });

            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumns: new[] { "EmployeeId", "RoleId" },
                keyValues: new object[] { -2, -1 });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: -3);
        }
    }
}
