using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameNight.Migrations
{
    public partial class ownerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayedOn",
                value: new DateTime(2021, 4, 14, 13, 24, 1, 697, DateTimeKind.Local).AddTicks(7055));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayedOn",
                value: new DateTime(2021, 4, 9, 11, 24, 23, 952, DateTimeKind.Local).AddTicks(3601));
        }
    }
}
