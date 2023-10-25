using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaGroup.Migrations
{
    public partial class AppToldMeToo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                column: "ConcurrencyStamp",
                value: "34c47795-4a5d-4b22-8acc-bb14747bd8f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11",
                column: "ConcurrencyStamp",
                value: "42ff42a0-8d0a-4ff6-8db6-9a8566a329f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "9f38b091-e6c4-4464-bdb8-7ab9f890af73");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                column: "ConcurrencyStamp",
                value: "ff919812-174b-4390-8ddc-c785c4324baa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5cb99a62-bceb-4b4a-98d7-b250d8d7ae11",
                column: "ConcurrencyStamp",
                value: "1cb42604-a426-4ad1-b4a0-b113f4e05dd5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "9ffb01bb-c7e3-4397-87e6-31755d5fa02f");
        }
    }
}
