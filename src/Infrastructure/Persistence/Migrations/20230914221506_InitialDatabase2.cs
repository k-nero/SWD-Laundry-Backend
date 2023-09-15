using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD_Laundry_Backend.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_AspNetUsers_ApplicationUserID",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_ApplicationUserID",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "Wallets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "Wallets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_ApplicationUserID",
                table: "Wallets",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_AspNetUsers_ApplicationUserID",
                table: "Wallets",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
