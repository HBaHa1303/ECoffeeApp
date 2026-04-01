using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECoffee.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", "Manager", new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "system" },
                    { 2L, new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", "Cashier", new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "system" },
                    { 3L, new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", "Barista", new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "system" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedBy", "DateOfBirth", "Email", "FullName", "PasswordHash", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1L, "TP.HCM", new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "system", new DateOnly(2026, 3, 25), "admin@gmail.com", "Hoàng Bá Hà", "HASHED_VALUE_HERE", new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "system" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1L, 1L });
        }
    }
}
