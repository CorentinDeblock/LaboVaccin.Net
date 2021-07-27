using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineCenter.DAL.Migrations
{
    public partial class ModifyPatientId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Communications");

            migrationBuilder.UpdateData(
                table: "InActivitties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Closing", "Opening" },
                values: new object[] { new DateTime(2022, 7, 27, 15, 41, 16, 190, DateTimeKind.Local).AddTicks(3886), new DateTime(2021, 7, 27, 15, 41, 16, 190, DateTimeKind.Local).AddTicks(3489) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Communications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "InActivitties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Closing", "Opening" },
                values: new object[] { new DateTime(2022, 7, 27, 15, 31, 4, 664, DateTimeKind.Local).AddTicks(3439), new DateTime(2021, 7, 27, 15, 31, 4, 664, DateTimeKind.Local).AddTicks(3068) });
        }
    }
}
