using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWD_Laundry_Backend.Repository.Migrations
{
    /// <inheritdoc />
    public partial class FixNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_ApplicationUserID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Buildings_BuildingID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_LaundryStores_AspNetUsers_ApplicationUserID",
                table: "LaundryStores");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistories_Orders_OrderID",
                table: "OrderHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Trips_Buildings_BuildingID",
                table: "Staff_Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Trips_Staffs_StaffID",
                table: "Staff_Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Trips_TimeSchedules_TimeScheduleID",
                table: "Staff_Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_AspNetUsers_ApplicationUserID",
                table: "Staffs");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Staffs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TimeScheduleID",
                table: "Staff_Trips",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StaffID",
                table: "Staff_Trips",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BuildingID",
                table: "Staff_Trips",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "OrderHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderID",
                table: "OrderHistories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "OrderHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LaundryStores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "LaundryStores",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "LaundryStores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BuildingID",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_ApplicationUserID",
                table: "Customers",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Buildings_BuildingID",
                table: "Customers",
                column: "BuildingID",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LaundryStores_AspNetUsers_ApplicationUserID",
                table: "LaundryStores",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistories_Orders_OrderID",
                table: "OrderHistories",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Trips_Buildings_BuildingID",
                table: "Staff_Trips",
                column: "BuildingID",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Trips_Staffs_StaffID",
                table: "Staff_Trips",
                column: "StaffID",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Trips_TimeSchedules_TimeScheduleID",
                table: "Staff_Trips",
                column: "TimeScheduleID",
                principalTable: "TimeSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_AspNetUsers_ApplicationUserID",
                table: "Staffs",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_ApplicationUserID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Buildings_BuildingID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_LaundryStores_AspNetUsers_ApplicationUserID",
                table: "LaundryStores");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistories_Orders_OrderID",
                table: "OrderHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Trips_Buildings_BuildingID",
                table: "Staff_Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Trips_Staffs_StaffID",
                table: "Staff_Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Trips_TimeSchedules_TimeScheduleID",
                table: "Staff_Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_AspNetUsers_ApplicationUserID",
                table: "Staffs");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Staffs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "TimeScheduleID",
                table: "Staff_Trips",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "StaffID",
                table: "Staff_Trips",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "BuildingID",
                table: "Staff_Trips",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "OrderHistories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "OrderID",
                table: "OrderHistories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "OrderHistories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LaundryStores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "LaundryStores",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "LaundryStores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BuildingID",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_ApplicationUserID",
                table: "Customers",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Buildings_BuildingID",
                table: "Customers",
                column: "BuildingID",
                principalTable: "Buildings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LaundryStores_AspNetUsers_ApplicationUserID",
                table: "LaundryStores",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistories_Orders_OrderID",
                table: "OrderHistories",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Trips_Buildings_BuildingID",
                table: "Staff_Trips",
                column: "BuildingID",
                principalTable: "Buildings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Trips_Staffs_StaffID",
                table: "Staff_Trips",
                column: "StaffID",
                principalTable: "Staffs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Trips_TimeSchedules_TimeScheduleID",
                table: "Staff_Trips",
                column: "TimeScheduleID",
                principalTable: "TimeSchedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_AspNetUsers_ApplicationUserID",
                table: "Staffs",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
