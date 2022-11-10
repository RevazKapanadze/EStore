using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStore.Migrations
{
    public partial class quantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29450fcf-393d-46db-9b7c-13163fa9a613");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0351938-a6cd-46d7-8df2-f9a7e2563ac2");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ITEM_DETAILS",
                type: "int",
                nullable: false,
                defaultValue: 0);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           /*  migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ITEM_DETAILS");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29450fcf-393d-46db-9b7c-13163fa9a613", "be87b36b-3a24-40f1-bc66-5a8c63b324b1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0351938-a6cd-46d7-8df2-f9a7e2563ac2", "769fee29-a042-4fbc-8e68-0ed7532070fc", "Admin", "ADMIN" });*/
        }
    }
}
