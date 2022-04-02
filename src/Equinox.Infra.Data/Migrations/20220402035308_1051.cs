using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Equinox.Infra.Data.Migrations
{
    public partial class _1051 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"), "Hành Chính Nhân Sự" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"));
        }
    }
}
