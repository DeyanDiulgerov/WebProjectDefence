using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProject.Data.Migrations
{
    public partial class UnitTestsSeedDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 33,
                column: "ReleaseDate",
                value: new DateTime(2022, 12, 8, 15, 31, 19, 565, DateTimeKind.Local).AddTicks(7828));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "AvailableFrom",
                value: new DateTime(2022, 12, 8, 15, 31, 19, 565, DateTimeKind.Local).AddTicks(7828));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 33,
                column: "ReleaseDate",
                value: new DateTime(2022, 12, 8, 15, 22, 18, 293, DateTimeKind.Local).AddTicks(5853));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "AvailableFrom",
                value: new DateTime(2022, 12, 8, 15, 22, 18, 293, DateTimeKind.Local).AddTicks(5853));
        }
    }
}
