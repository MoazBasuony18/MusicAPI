using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicAPI.Migrations
{
    public partial class updateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateReleased",
                value: new DateTime(2022, 9, 22, 19, 31, 56, 483, DateTimeKind.Local).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateReleased",
                value: new DateTime(2021, 8, 18, 19, 31, 56, 483, DateTimeKind.Local).AddTicks(1766));

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateReleased",
                value: new DateTime(2013, 2, 19, 19, 31, 56, 483, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateReleased",
                value: new DateTime(2015, 8, 19, 19, 31, 56, 483, DateTimeKind.Local).AddTicks(1776));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateReleased",
                value: new DateTime(2022, 9, 22, 19, 29, 34, 553, DateTimeKind.Local).AddTicks(6572));

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateReleased",
                value: new DateTime(2021, 8, 18, 19, 29, 34, 553, DateTimeKind.Local).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateReleased",
                value: new DateTime(2033, 2, 19, 19, 29, 34, 553, DateTimeKind.Local).AddTicks(6633));

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateReleased",
                value: new DateTime(2015, 8, 19, 19, 29, 34, 553, DateTimeKind.Local).AddTicks(6638));
        }
    }
}
