using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Playground.Migrations
{
    public partial class AddedOfficeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Departments",
                nullable: false,
                defaultValue: -1);

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    OfficeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.OfficeId);
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: -3,
                column: "PhoneNumber",
                value: "+1234567895");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: -2,
                column: "PhoneNumber",
                value: "+1234567894");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: -1,
                column: "PhoneNumber",
                value: "+1234567893");

            migrationBuilder.InsertData(
                table: "Office",
                columns: new[] { "OfficeId", "PhoneNumber", "PostalCode", "Title" },
                values: new object[,]
                {
                    { -1, "+1234567891", "SK2 5JY", "London (HQ)" },
                    { -2, "+1234567892", "10001", "New York" }
                });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: -3,
                column: "OfficeId",
                value: -2);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: -2,
                column: "OfficeId",
                value: -1);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: -1,
                column: "OfficeId",
                value: -1);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_OfficeId",
                table: "Departments",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Office_OfficeId",
                table: "Departments",
                column: "OfficeId",
                principalTable: "Office",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Cascade);

            // Run Raw SQL to update the Foreign Key of the Department added before The Office Entity    
            migrationBuilder.Sql("UPDATE Departments SET OfficeId = -2 WHERE Title = 'Finance'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Office_OfficeId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropIndex(
                name: "IX_Departments_OfficeId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Departments");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: -3,
                column: "PhoneNumber",
                value: "+1237891013");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: -2,
                column: "PhoneNumber",
                value: "+1237891011");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: -1,
                column: "PhoneNumber",
                value: "+123456789");            
        }
    }
}
