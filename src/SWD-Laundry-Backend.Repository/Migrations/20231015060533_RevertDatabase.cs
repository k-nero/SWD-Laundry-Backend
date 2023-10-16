using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD_Laundry_Backend.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RevertDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderType",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "OrderHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "OrderHistories",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderType",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "OrderHistories");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "OrderHistories");
        }
    }
}
