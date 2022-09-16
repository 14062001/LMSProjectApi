using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LMSProjectApi.Migrations
{
    public partial class initlms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Emp_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emp_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emp_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emp_Mobileno = table.Column<int>(type: "int", nullable: false),
                    Emp_Doj = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Emp_Dept = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avail_Leave_Bal = table.Column<int>(type: "int", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emp_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emp_Repassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Emp_Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Manager_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manager_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager_Mobileno = table.Column<int>(type: "int", nullable: false),
                    Manager_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager_Repassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emp_id = table.Column<int>(type: "int", nullable: false),
                    EmployeeEmp_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Manager_Id);
                    table.ForeignKey(
                        name: "FK_Managers_Employees_EmployeeEmp_Id",
                        column: x => x.EmployeeEmp_Id,
                        principalTable: "Employees",
                        principalColumn: "Emp_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leave",
                columns: table => new
                {
                    Leave_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfDays = table.Column<int>(type: "int", nullable: false),
                    Start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Leave_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Applied_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Manager_Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emp_id = table.Column<int>(type: "int", nullable: false),
                    Manager_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave", x => x.Leave_Id);
                    table.ForeignKey(
                        name: "FK_Leave_Employees_Emp_id",
                        column: x => x.Emp_id,
                        principalTable: "Employees",
                        principalColumn: "Emp_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leave_Managers_Manager_id",
                        column: x => x.Manager_id,
                        principalTable: "Managers",
                        principalColumn: "Manager_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leave_Emp_id",
                table: "Leave",
                column: "Emp_id");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_Manager_id",
                table: "Leave",
                column: "Manager_id");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_EmployeeEmp_Id",
                table: "Managers",
                column: "EmployeeEmp_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leave");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
