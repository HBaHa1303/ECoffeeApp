using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECoffee.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserTable_DayOfBirth_Colum_To_DateOfBirth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DayOfBirth",
                table: "Users",
                newName: "DateOfBirth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Users",
                newName: "DayOfBirth");
        }
    }
}
