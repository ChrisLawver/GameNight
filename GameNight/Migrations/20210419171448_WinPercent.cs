using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameNight.Migrations
{
    public partial class WinPercent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayedOn",
                value: new DateTime(2021, 4, 19, 13, 14, 47, 596, DateTimeKind.Local).AddTicks(8198));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayedOn",
                value: new DateTime(2021, 4, 16, 10, 26, 49, 653, DateTimeKind.Local).AddTicks(8679));
        }
    }
}
