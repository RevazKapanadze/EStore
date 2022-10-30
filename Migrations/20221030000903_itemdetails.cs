using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStore.Migrations
{
    public partial class itemdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b6f6a50-07a4-4878-90bf-a34ecb1cb6c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5baf4109-25d7-48de-b1cf-acd47d0a27e4");

            migrationBuilder.AlterColumn<int>(
                name: "Main_Category",
                table: "ITEMS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "item_Logo",
                table: "ITEM_PHOTOES",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "ITEM_DETAILS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ITEM_DETAILS",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Sale",
                table: "ITEM_DETAILS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "ITEM_DETAILS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "620aee91-2abd-4392-8042-733526803f5c", "72d2d385-18ac-4f6e-a7ce-3cdc7b627bf1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7fefc7f6-dbef-4038-b0d5-1891ef357325", "63d36863-cd5a-4eb3-a010-bc7cc5ee7f32", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "620aee91-2abd-4392-8042-733526803f5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fefc7f6-dbef-4038-b0d5-1891ef357325");

            migrationBuilder.DropColumn(
                name: "item_Logo",
                table: "ITEM_PHOTOES");

            migrationBuilder.DropColumn(
                name: "Colour",
                table: "ITEM_DETAILS");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ITEM_DETAILS");

            migrationBuilder.DropColumn(
                name: "Sale",
                table: "ITEM_DETAILS");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "ITEM_DETAILS");

            migrationBuilder.AlterColumn<string>(
                name: "Main_Category",
                table: "ITEMS",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3b6f6a50-07a4-4878-90bf-a34ecb1cb6c2", "d59669c0-9893-4248-b731-a88900ef109b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5baf4109-25d7-48de-b1cf-acd47d0a27e4", "3fb6e4eb-0e45-4a7c-98e2-b98f36c4c486", "Admin", "ADMIN" });
        }
    }
}
