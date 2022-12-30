using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStore.Data.Migrations
{
    public partial class reseeing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0f14fefd-710b-4a16-a881-818b0bffa82e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7908d300-9f65-44a9-aedc-169eb376c98d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "a1c2507b-83d3-4202-b19f-ffa026aac04c");

            migrationBuilder.InsertData(
                table: "CATEGORY",
                columns: new[] { "Id", "Description", "Name", "mainCategory_Id" },
                values: new object[,]
                {
                    { 2, "მართლა ჩექმა", "ჩექმა", 1 },
                    { 3, "მართლა სანდალი", "სანდალი", 1 }
                });

            migrationBuilder.InsertData(
                table: "MAINCATEGORY",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 2, "მართლა შარვალი", "შარვალი" },
                    { 3, "მართლა ჰუდი", "ჰუდი" }
                });

            migrationBuilder.InsertData(
                table: "CATEGORY",
                columns: new[] { "Id", "Description", "Name", "mainCategory_Id" },
                values: new object[] { 4, "მართლა კლასიკური", "კლასიკური", 2 });

            migrationBuilder.UpdateData(
                table: "ITEMS",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Category_Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ITEMS",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Category_Id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ITEMS",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Category_Id", "Main_Category" },
                values: new object[] { 4, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CATEGORY",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CATEGORY",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CATEGORY",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MAINCATEGORY",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MAINCATEGORY",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "00634f22-d303-4544-9b87-79ec70dabf2c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "520862a9-d2c7-4d1e-91d0-6c8b7de3de44");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "8bb33c3c-c73b-4793-9ea8-22b9e2ea01bc");

            migrationBuilder.UpdateData(
                table: "ITEMS",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Category_Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ITEMS",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Category_Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ITEMS",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Category_Id", "Main_Category" },
                values: new object[] { 1, 1 });
        }
    }
}
