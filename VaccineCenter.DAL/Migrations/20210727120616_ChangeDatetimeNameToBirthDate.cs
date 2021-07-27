using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineCenter.DAL.Migrations
{
    public partial class ChangeDatetimeNameToBirthDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Patients",
                newName: "BirthDate");

            migrationBuilder.UpdateData(
                table: "InActivitties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Closing", "Opening" },
                values: new object[] { new DateTime(2022, 7, 27, 14, 6, 16, 124, DateTimeKind.Local).AddTicks(4416), new DateTime(2021, 7, 27, 14, 6, 16, 124, DateTimeKind.Local).AddTicks(4049) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Patients",
                newName: "DateTime");

            migrationBuilder.UpdateData(
                table: "InActivitties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Closing", "Opening" },
                values: new object[] { new DateTime(2022, 7, 27, 13, 27, 19, 702, DateTimeKind.Local).AddTicks(1419), new DateTime(2021, 7, 27, 13, 27, 19, 702, DateTimeKind.Local).AddTicks(1080) });
        }
    }
}
