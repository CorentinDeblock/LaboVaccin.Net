using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VaccineCenter.DAL.Migrations
{
    public partial class ModifyNRN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NationalRegistrationNumber",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "InActivitties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Closing", "Opening" },
                values: new object[] { new DateTime(2022, 7, 27, 15, 31, 4, 664, DateTimeKind.Local).AddTicks(3439), new DateTime(2021, 7, 27, 15, 31, 4, 664, DateTimeKind.Local).AddTicks(3068) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "NationalRegistrationNumber",
                table: "Patients",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "InActivitties",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Closing", "Opening" },
                values: new object[] { new DateTime(2022, 7, 27, 14, 6, 16, 124, DateTimeKind.Local).AddTicks(4416), new DateTime(2021, 7, 27, 14, 6, 16, 124, DateTimeKind.Local).AddTicks(4049) });
        }
    }
}
