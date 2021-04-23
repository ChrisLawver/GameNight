using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameNight.Migrations
{
    public partial class addGameAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxPlayers",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinPlayers",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayedOn",
                value: new DateTime(2021, 4, 9, 11, 24, 23, 952, DateTimeKind.Local).AddTicks(3601));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "MaxPlayers",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "MinPlayers",
                table: "Games");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlayedOn",
                value: new DateTime(2021, 4, 9, 10, 31, 0, 705, DateTimeKind.Local).AddTicks(592));
        }
    }
}
