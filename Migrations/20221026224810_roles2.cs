using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStore.Migrations
{
    public partial class roles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57e496ea-f3e6-46cb-8719-f86adfd882ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a84a66d-12a8-4605-bd90-eb0a85ecb611");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f34f060-95ca-4b42-a490-765d0e11194a", "d566140a-f71c-46a6-913d-daad1dcf73de", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "abcface7-3cab-4264-8c39-7d586aba2f7c", "55fed05d-f411-4c6e-8dc7-24800a85aacc", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f34f060-95ca-4b42-a490-765d0e11194a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abcface7-3cab-4264-8c39-7d586aba2f7c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "57e496ea-f3e6-46cb-8719-f86adfd882ab", "ef4c8379-d0e4-4f28-9184-378568dbd4c5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a84a66d-12a8-4605-bd90-eb0a85ecb611", "c2a1442d-50eb-4851-a068-2c09da228714", "Company", "COMPANY" });
        }
    }
}
