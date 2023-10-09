using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaGroup.Data.Migrations
{
    public partial class AccountFinalTouches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                column: "ConcurrencyStamp",
                value: "8dede8c8-2929-4b6f-8ebe-b81c15163dbc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4280b6a-0613-4cbd-a9e6-f1701e926e73",
                column: "ConcurrencyStamp",
                value: "a0bfa234-317b-4068-a727-82625cafc370");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "employee@hizza.com", "EMPLOYEE@HIZZA.COM", "EMPLOYEE@HIZZA.COM", "employee@hizza.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "22d6208e-e968-487e-a8f6-59a1c3ce94d7",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "student@myemail.com", "STUDENT@MYEMAIL.COM", "STUDENT@MYEMAIL.COM", "student@myemail.com" });
        }
    }
}
