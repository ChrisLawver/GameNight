using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameNight.Migrations
{
    public partial class addedActiveBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayedOn",
                value: new DateTime(2021, 4, 14, 14, 28, 1, 453, DateTimeKind.Local).AddTicks(918));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayedOn",
                value: new DateTime(2021, 4, 14, 13, 24, 1, 697, DateTimeKind.Local).AddTicks(7055));
        }
    }
}
