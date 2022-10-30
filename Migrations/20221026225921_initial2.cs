using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStore.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "3b6f6a50-07a4-4878-90bf-a34ecb1cb6c2", "d59669c0-9893-4248-b731-a88900ef109b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5baf4109-25d7-48de-b1cf-acd47d0a27e4", "3fb6e4eb-0e45-4a7c-98e2-b98f36c4c486", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b6f6a50-07a4-4878-90bf-a34ecb1cb6c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5baf4109-25d7-48de-b1cf-acd47d0a27e4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f34f060-95ca-4b42-a490-765d0e11194a", "d566140a-f71c-46a6-913d-daad1dcf73de", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "abcface7-3cab-4264-8c39-7d586aba2f7c", "55fed05d-f411-4c6e-8dc7-24800a85aacc", "User", "USER" });
        }
    }
}
