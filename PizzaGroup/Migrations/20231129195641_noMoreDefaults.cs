using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaGroup.Migrations
{
    public partial class noMoreDefaults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                column: "ConcurrencyStamp",
                value: "94612a7c-9982-46a1-bef1-a4cca2d04e37");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11",
                column: "ConcurrencyStamp",
                value: "04292d4d-e1dd-471e-9a9b-69ae530f28e0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "6bc07960-be0f-434f-8c38-a7976dd750d9");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                column: "ConcurrencyStamp",
                value: "d534537b-7198-4cc7-ac8e-6934c8c0a44f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11",
                column: "ConcurrencyStamp",
                value: "57af5ce7-c956-4631-9cd3-10f8356855b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "1d08555a-c272-4923-8842-63f213adb3f0");

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "CrustId", "Name", "Price", "SizeId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Pepperoni", 5.0m, 1, null },
                    { 2, 2, "Beef", 8.5m, 2, null },
                    { 3, 3, "Cheese", 8.0m, 3, null },
                    { 4, 4, "Canadian Bacon", 12.25m, 4, null },
                    { 5, 5, "Sausage", 14.0m, 4, null },
                    { 6, 6, "Chicken Alfredo", 18.25m, 4, null },
                    { 7, 2, "Hawaiian", 5.5m, 1, null },
                    { 8, 3, "BBQ Chicken", 14.0m, 3, null },
                    { 9, 4, "Meat Lovers", 10.0m, 2, null },
                    { 10, 4, "Veggie Lovers", 10.0m, 3, null },
                    { 11, 5, "Hizza Special", 16.75m, 4, null },
                    { 12, 6, "Anchovie", 5.0m, 1, null },
                    { 13, 5, "Leo's Special", 15.0m, 4, null },
                    { 14, 1, "John's Special", 15.0m, 4, null },
                    { 15, 2, "Cameron's Special", 15.5m, 4, null },
                    { 16, 3, "Ryan's Special", 15.25m, 4, null },
                    { 17, 4, "Madelon's Special", 15.25m, 4, null }
                });
        }
    }
}
