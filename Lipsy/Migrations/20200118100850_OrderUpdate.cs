using Microsoft.EntityFrameworkCore.Migrations;

namespace Lipsy.Migrations
{
    public partial class OrderUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Lipsticks_LipstickId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DrinkId",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "LipstickId",
                table: "OrderDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Lipsticks_LipstickId",
                table: "OrderDetails",
                column: "LipstickId",
                principalTable: "Lipsticks",
                principalColumn: "LipstickId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Lipsticks_LipstickId",
                table: "OrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "LipstickId",
                table: "OrderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "DrinkId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Lipsticks_LipstickId",
                table: "OrderDetails",
                column: "LipstickId",
                principalTable: "Lipsticks",
                principalColumn: "LipstickId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
