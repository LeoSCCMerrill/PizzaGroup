using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaGroup.Migrations
{
    public partial class OrderChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inches = table.Column<int>(type: "int", nullable: false),
                    PriceMultiplier = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToppingType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    CrustId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzas_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pizzas_Crusts_CrustId",
                        column: x => x.CrustId,
                        principalTable: "Crusts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizzas_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPizzas",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPizzas", x => new { x.OrderId, x.PizzaId });
                    table.ForeignKey(
                        name: "FK_OrderPizzas_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPizzas_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaToppings",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    ToppingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaToppings", x => new { x.PizzaId, x.ToppingId });
                    table.ForeignKey(
                        name: "FK_PizzaToppings_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaToppings_Toppings_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Toppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22d6208e-e968-487e-a8f6-59a1c3ce94d7", "24dfe32a-5f6e-4563-b821-48bd829cc974", "Employee", "EMPLOYEE" },
                    { "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11", "44b1c3ec-69fc-4a25-beed-b18ad66fd4b0", "Owner", "OWNER" },
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "c2005201-14ff-4142-8f31-cf6f15acb4ea", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "22d6208e-e968-487e-a8f6-59a1c3ce94d7", 0, "1", "employee@hizza.com", true, false, null, "EMPLOYEE@HIZZA.COM", "EMPLOYEE@HIZZA.COM", "AQAAAAEAACcQAAAAEALfXOO0MYDpnaWi+2TO6u67hE3xzrew03QVb8Vb3wTOdiKZzWGSm42SscHBRPRT0g==", null, false, "1", false, "employee@hizza.com" },
                    { "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11", 0, "c8554266-b401-4519-9aeb-a9283053fc58", "owner@hizza.com", true, false, null, "OWNER@HIZZA.COM", "OWNER@HIZZA.COM", "AQAAAAEAACcQAAAAEALfXOO0MYDpnaWi+2TO6u67hE3xzrew03QVb8Vb3wTOdiKZzWGSm42SscHBRPRT0g==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA", false, "owner@hizza.com" },
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", 0, "c8554266-b401-4519-9aeb-a9283053fc58", "manager@hizza.com", true, false, null, "MANAGER@HIZZA.COM", "MANAGER@HIZZA.COM", "AQAAAAEAACcQAAAAEALfXOO0MYDpnaWi+2TO6u67hE3xzrew03QVb8Vb3wTOdiKZzWGSm42SscHBRPRT0g==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA", false, "manager@hizza.com" }
                });

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "Id", "Name", "Price" },
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
                columns: new[] { "Id", "Inches", "Name", "PriceMultiplier" },
                values: new object[,]
                {
                    { 1, 8, "Mini", 0.50m },
                    { 2, 10, "Small", 0.75m },
                    { 3, 12, "Medium", 1m },
                    { 4, 14, "Large", 1.25m }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "Id", "Name", "Price", "ToppingType" },
                values: new object[,]
                {
                    { 1, "Pepperoni", 0.29m, 0 },
                    { 2, "Beef", 0.29m, 0 },
                    { 3, "Bacon", 0.29m, 0 },
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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "22d6208e-e968-487e-a8f6-59a1c3ce94d7", "22d6208e-e968-487e-a8f6-59a1c3ce94d7" },
                    { "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11", "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11" },
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "b4280b6a-0613-4cbd-a9e6-f1701e926e73" }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "CrustId", "Name", "SizeId", "UserId" },
                values: new object[] { 1, 1, "Custom 1", 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizzas_PizzaId",
                table: "OrderPizzas",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustId",
                table: "Pizzas",
                column: "CrustId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeId",
                table: "Pizzas",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_UserId",
                table: "Pizzas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaToppings_ToppingId",
                table: "PizzaToppings",
                column: "ToppingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderPizzas");

            migrationBuilder.DropTable(
                name: "PizzaToppings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Sizes");
        }
    }
}
