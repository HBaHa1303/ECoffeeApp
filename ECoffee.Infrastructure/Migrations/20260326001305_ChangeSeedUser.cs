using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECoffee.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Address", "DayOfBirth" },
                values: new object[] { "TP.HCM", new DateOnly(2026, 3, 25) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Address", "DayOfBirth" },
                values: new object[] { "", new DateOnly(1, 1, 1) });
        }
    }
}
