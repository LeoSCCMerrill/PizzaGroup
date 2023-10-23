using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaGroup.Data.Migrations
{
    public partial class addEmpIDToOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "customerID",
                table: "Orders",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "PizzaID",
                table: "Orders",
                newName: "EmployeeID");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "Pizzas",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                column: "ConcurrencyStamp",
                value: "f9a26cca-809d-4910-9e15-db76338ec90f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11",
                column: "ConcurrencyStamp",
                value: "3ac3b150-3ada-4140-b306-cc00c0d759c3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "e27dc38c-7b0f-4a44-ba75-f8a6b45e4ff3");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderID",
                table: "Pizzas",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Orders_OrderID",
                table: "Pizzas",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Orders_OrderID",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_OrderID",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Orders",
                newName: "customerID");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Orders",
                newName: "PizzaID");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                column: "ConcurrencyStamp",
                value: "5abfc754-ff32-4536-9f8e-f9ce5a680578");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11",
                column: "ConcurrencyStamp",
                value: "9939d580-c30f-4b8f-980d-00f5925b6f00");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "c2f22047-3913-4b25-a9dd-8c3c98179d1d");
        }
    }
}
