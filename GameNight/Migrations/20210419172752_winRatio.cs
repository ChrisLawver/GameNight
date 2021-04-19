using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameNight.Migrations
{
    public partial class winRatio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "WinPercent",
                table: "Users",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayedOn",
                value: new DateTime(2021, 4, 19, 13, 27, 51, 313, DateTimeKind.Local).AddTicks(5567));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WinPercent",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayedOn",
                value: new DateTime(2021, 4, 19, 13, 14, 47, 596, DateTimeKind.Local).AddTicks(8198));
        }
    }
}
