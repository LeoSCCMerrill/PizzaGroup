using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaGroup.Data.Migrations
{
    public partial class toppings1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    PizzaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PizzaPrice = table.Column<int>(type: "int", nullable: false),
                    PizzaSize = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.PizzaID);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    ToppingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToppingName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.ToppingID);
                });

            migrationBuilder.CreateTable(
                name: "PizzaToppings",
                columns: table => new
                {
                    PizzaID = table.Column<int>(type: "int", nullable: false),
                    ToppingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaToppings", x => new { x.PizzaID, x.ToppingID });
                    table.ForeignKey(
                        name: "FK_PizzaToppings_Pizzas_PizzaID",
                        column: x => x.PizzaID,
                        principalTable: "Pizzas",
                        principalColumn: "PizzaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaToppings_Toppings_ToppingID",
                        column: x => x.ToppingID,
                        principalTable: "Toppings",
                        principalColumn: "ToppingID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaID", "PizzaName", "PizzaPrice", "PizzaSize" },
                values: new object[] { 1, "Custom 1", 10, "Medium" });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingID", "ToppingName" },
                values: new object[,]
                {
                    { 1, "Pepperoni" },
                    { 2, "Beef" }
                });

            migrationBuilder.InsertData(
                table: "PizzaToppings",
                columns: new[] { "PizzaID", "ToppingID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "PizzaToppings",
                columns: new[] { "PizzaID", "ToppingID" },
                values: new object[] { 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaToppings_ToppingID",
                table: "PizzaToppings",
                column: "ToppingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaToppings");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                column: "ConcurrencyStamp",
                value: "5210f0c0-cc3b-49c4-93c7-50dada821ad5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "481c5696-c19a-454b-8300-2e5af9db03ad");
        }
    }
}
