using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaGroup.Data.Migrations
{
    public partial class pizzaprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PizzaPrice",
                table: "Pizzas",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                column: "ConcurrencyStamp",
                value: "b3576165-3c2d-47f6-b33a-f6d564b8e471");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "9b45f4dd-38f0-4d1e-b1ae-729a58d65fa1");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaID",
                keyValue: 1,
                column: "PizzaPrice",
                value: 10.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PizzaPrice",
                table: "Pizzas",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                column: "ConcurrencyStamp",
                value: "c8765029-7f5a-4f4d-b858-812fe195fb99");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "02fc1241-f5dd-4c9f-bf65-bb28af6e5b9c");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaID",
                keyValue: 1,
                column: "PizzaPrice",
                value: 10);
        }
    }
}
