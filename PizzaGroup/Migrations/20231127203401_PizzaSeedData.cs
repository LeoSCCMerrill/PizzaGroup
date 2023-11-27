using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaGroup.Migrations
{
    public partial class PizzaSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Toppings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                column: "ConcurrencyStamp",
                value: "cb995e7e-b522-448e-8a6f-c74725a0a2bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11",
                column: "ConcurrencyStamp",
                value: "3c376665-381f-4147-be32-60ddf8636c01");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "5ea41251-1801-4025-bf10-cd8395db17b9");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Pepperoni");

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "CrustId", "Name", "Price", "SizeId", "UserId" },
                values: new object[,]
                {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Toppings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                column: "ConcurrencyStamp",
                value: "46230871-34e5-4de3-abcd-c1f5914fd418");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11",
                column: "ConcurrencyStamp",
                value: "bde81df1-bb5b-4027-b3d7-2cd5a8d1d1c3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "f28651a9-3a89-4623-936b-355a23e42252");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Custom 1");
        }
    }
}
