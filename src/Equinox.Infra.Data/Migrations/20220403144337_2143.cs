using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Equinox.Infra.Data.Migrations
{
    public partial class _2143 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Learning",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    University = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Learning", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLearning",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LearningId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Major = table.Column<string>(type: "varchar(100)", nullable: true),
                    Qualification = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLearning", x => new { x.EmployeeId, x.LearningId });
                    table.ForeignKey(
                        name: "FK_EmployeeLearning_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLearning_Learning_LearningId",
                        column: x => x.LearningId,
                        principalTable: "Learning",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLearning_LearningId",
                table: "EmployeeLearning",
                column: "LearningId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeLearning");

            migrationBuilder.DropTable(
                name: "Learning");
        }
    }
}
