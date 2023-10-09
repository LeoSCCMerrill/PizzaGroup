using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaGroup.Data.Migrations
{
    public partial class OwnerAccountAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                column: "ConcurrencyStamp",
                value: "36d5b3a4-f33e-4b7b-b04d-ba66bcfdc1fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "9170c33b-dfae-4b6b-a06b-350810da3efa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11", "e4f00b84-e6dd-40a3-a59a-9e77e03361a8", "Owner", "OWNER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11", 0, "c8554266-b401-4519-9aeb-a9283053fc58", "owner@hizza.com", true, false, null, "OWNER@HIZZA.COM", "OWNER@HIZZA.COM", "AQAAAAEAACcQAAAAEALfXOO0MYDpnaWi+2TO6u67hE3xzrew03QVb8Vb3wTOdiKZzWGSm42SscHBRPRT0g==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA", false, "owner@hizza.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11", "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11", "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                column: "ConcurrencyStamp",
                value: "2e7c69fc-3856-4923-8515-9f9a8d3833b7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "6bc95c27-10ea-4d58-95c1-19d2a1dec8ce");
        }
    }
}
