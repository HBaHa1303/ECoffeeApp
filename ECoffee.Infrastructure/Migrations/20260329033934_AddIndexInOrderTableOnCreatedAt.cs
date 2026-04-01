using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECoffee.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexInOrderTableOnCreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedAt",
                table: "Orders",
                column: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_CreatedAt",
                table: "Orders");
        }
    }
}
