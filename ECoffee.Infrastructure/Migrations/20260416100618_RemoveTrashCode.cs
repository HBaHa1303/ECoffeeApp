using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECoffee.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTrashCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShiftEntity_ShiftId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShiftEntity_Users_UserId",
                table: "ShiftEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShiftEntity",
                table: "ShiftEntity");

            migrationBuilder.RenameTable(
                name: "ShiftEntity",
                newName: "Shifts");

            migrationBuilder.RenameIndex(
                name: "IX_ShiftEntity_UserId",
                table: "Shifts",
                newName: "IX_Shifts_UserId");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalRevenue",
                table: "Shifts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shifts_ShiftId",
                table: "Orders",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Users_UserId",
                table: "Shifts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shifts_ShiftId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_Users_UserId",
                table: "Shifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "TotalRevenue",
                table: "Shifts");

            migrationBuilder.RenameTable(
                name: "Shifts",
                newName: "ShiftEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Shifts_UserId",
                table: "ShiftEntity",
                newName: "IX_ShiftEntity_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShiftEntity",
                table: "ShiftEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShiftEntity_ShiftId",
                table: "Orders",
                column: "ShiftId",
                principalTable: "ShiftEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShiftEntity_Users_UserId",
                table: "ShiftEntity",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
