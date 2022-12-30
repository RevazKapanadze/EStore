using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStore.Data.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "MAINCATEGORY",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "მართლა ფეხსაცმელი", "ფეხსაცმელი" });

            migrationBuilder.InsertData(
                table: "CATEGORY",
                columns: new[] { "Id", "Description", "Name", "mainCategory_Id" },
                values: new object[] { 1, "მართლა კედი", "კედი", 1 });

            migrationBuilder.InsertData(
                table: "ITEMS",
                columns: new[] { "Id", "Category_Id", "Company_Id", "Is_Active", "Main_Category", "Main_Photo", "Price", "Quantity", "Short_Description", "Short_Name" },
                values: new object[,]
                {
                    { 1L, 1, 1, 1, 1, "https://icrshop.ge/assets/local/catalog/470374-51094_1.jpg?v=2.74", 399m, 1, "Ecco Soft 7", "Ecco Soft 7" },
                    { 2L, 1, 1, 1, 1, "https://icrshop.ge/assets/local/catalog/470374-51094_1.jpg?v=2.74", 399m, 1, "Ecco Soft 7", "Ecco Soft 7" },
                    { 3L, 1, 1, 1, 1, "https://icrshop.ge/assets/local/catalog/470374-51094_1.jpg?v=2.74", 399m, 1, "Ecco Soft 7", "Ecco Soft 7" },
                    { 4L, 1, 1, 1, 1, "https://icrshop.ge/assets/local/catalog/470374-51094_1.jpg?v=2.74", 399m, 1, "Ecco Soft 7", "Ecco Soft 7" },
                    { 5L, 1, 1, 1, 1, "https://icrshop.ge/assets/local/catalog/470374-51094_1.jpg?v=2.74", 399m, 1, "Ecco Soft 7", "Ecco Soft 7" },
                    { 6L, 1, 1, 1, 1, "https://icrshop.ge/assets/local/catalog/470374-51094_1.jpg?v=2.74", 399m, 1, "Ecco Soft 7", "Ecco Soft 7" },
                    { 7L, 1, 1, 1, 1, "https://icrshop.ge/assets/local/catalog/470374-51094_1.jpg?v=2.74", 399m, 1, "Ecco Soft 7", "Ecco Soft 7" },
                    { 8L, 1, 1, 1, 1, "https://icrshop.ge/assets/local/catalog/470374-51094_1.jpg?v=2.74", 399m, 1, "Ecco Soft 7", "Ecco Soft 7" },
                    { 9L, 1, 1, 1, 1, "https://icrshop.ge/assets/local/catalog/470374-51094_1.jpg?v=2.74", 399m, 1, "Ecco Soft 7", "Ecco Soft 7" },
                    { 10L, 1, 1, 1, 1, "https://icrshop.ge/assets/local/catalog/470374-51094_1.jpg?v=2.74", 399m, 1, "Ecco Soft 7", "Ecco Soft 7" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ITEMS",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ITEMS",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ITEMS",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ITEMS",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ITEMS",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ITEMS",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ITEMS",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "ITEMS",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "ITEMS",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "ITEMS",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "CATEGORY",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MAINCATEGORY",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "165e27fe-6f39-4cd2-933d-736854997506");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "15a3c463-f191-469a-b1b2-24212fbb23f4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f8f4c345-21db-493d-8927-de85186dd7d7");
        }
    }
}
