using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD_Laundry_Backend.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTransaction2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transaction");
        }
    }
}
