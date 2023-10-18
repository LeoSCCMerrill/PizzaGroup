using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaGroup.Migrations
{
    public partial class sizeCrustChanges1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                column: "ConcurrencyStamp",
                value: "8a0d9a1e-0f9b-4b43-ba28-9ff719823da3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11",
                column: "ConcurrencyStamp",
                value: "33e32c46-f84c-4e2c-855d-835abb885d2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "96859f68-b207-431f-8a5a-6c912c1523e1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                column: "ConcurrencyStamp",
                value: "f7746335-c09c-43e5-8560-47254aaae66f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11",
                column: "ConcurrencyStamp",
                value: "1cfe6f53-032f-4985-a3d4-b3fb64e50f83");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "508e48c0-5ea3-4381-8843-7cfc2c252068");
        }
    }
}
