using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaGroup.Data.Migrations
{
    public partial class DefaultPizzaTopping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ToppingPrice",
                table: "Toppings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ToppingType",
                table: "Toppings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    CrustId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrustName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrustPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.CrustId);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeInches = table.Column<int>(type: "int", nullable: false),
                    SizePriceMultiplier = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeId);
                });

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

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "CrustId", "CrustName", "CrustPrice" },
                values: new object[,]
                {
                    { 1, "Original Crust", 0m },
                    { 2, "Pan Crust", 0m },
                    { 3, "Thin Crust", 0m },
                    { 4, "Stuffed Crust", 1.00m },
                    { 5, "Detroit Style", 2.00m },
                    { 6, "Chicago Style", 4.00m }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "SizeInches", "SizeName", "SizePriceMultiplier" },
                values: new object[,]
                {
                    { 1, 8, "Mini", 0.50m },
                    { 2, 10, "Small", 0.75m },
                    { 3, 12, "Medium", 1m },
                    { 4, 14, "Large", 1.25m }
                });

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 1,
                column: "ToppingPrice",
                value: 0.29m);

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 2,
                column: "ToppingPrice",
                value: 0.29m);

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 3,
                columns: new[] { "ToppingName", "ToppingPrice" },
                values: new object[] { "Bacon", 0.29m });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingID", "ToppingName", "ToppingPrice", "ToppingType" },
                values: new object[,]
                {
                    { 4, "Chicken", 0.29m, 0 },
                    { 5, "Sausage", 0.29m, 0 },
                    { 6, "Canadian Bacon", 0.29m, 0 },
                    { 7, "Anchovies", 0.29m, 0 },
                    { 8, "Mozzarella", 0m, 1 },
                    { 9, "Parmesan", 0m, 1 },
                    { 10, "Green Pepper", 0.19m, 2 },
                    { 11, "Red Pepper", 0.19m, 2 },
                    { 12, "Onion", 0.19m, 2 },
                    { 13, "Red Onion", 0.19m, 2 },
                    { 14, "Mushroom", 0.19m, 2 },
                    { 15, "Olive", 0.19m, 2 },
                    { 16, "Pineapple", 0.19m, 2 },
                    { 17, "Tomato Sauce", 0m, 3 },
                    { 18, "Barbeque", 0.09m, 3 },
                    { 19, "Alfredo", 0.19m, 3 },
                    { 20, "Buffalo", 0.19m, 3 },
                    { 21, "Seasoned Crust", 0.49m, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 21);

            migrationBuilder.DropColumn(
                name: "ToppingPrice",
                table: "Toppings");

            migrationBuilder.DropColumn(
                name: "ToppingType",
                table: "Toppings");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                column: "ConcurrencyStamp",
                value: "192813a5-2366-4288-98e9-268ea4a1380e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11",
                column: "ConcurrencyStamp",
                value: "784af372-8092-41fc-87b0-2287fb548253");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "b946b5d3-85aa-4e5f-8e63-fef6b7732cb1");

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "ToppingID",
                keyValue: 3,
                column: "ToppingName",
                value: "Do not use");
        }
    }
}
