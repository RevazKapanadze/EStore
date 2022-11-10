using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStore.Migrations
{
    public partial class FKFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITEM_DETAILS_ITEMS_Id",
                table: "ITEM_DETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_ITEM_PHOTOES_ITEMS_Id",
                table: "ITEM_PHOTOES");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "620aee91-2abd-4392-8042-733526803f5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fefc7f6-dbef-4038-b0d5-1891ef357325");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "ITEM_PHOTOES",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "ITEM_DETAILS",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29450fcf-393d-46db-9b7c-13163fa9a613", "be87b36b-3a24-40f1-bc66-5a8c63b324b1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0351938-a6cd-46d7-8df2-f9a7e2563ac2", "769fee29-a042-4fbc-8e68-0ed7532070fc", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_ITEM_PHOTOES_Item_Id",
                table: "ITEM_PHOTOES",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ITEM_DETAILS_Item_Id",
                table: "ITEM_DETAILS",
                column: "Item_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ITEM_DETAILS_ITEMS_Item_Id",
                table: "ITEM_DETAILS",
                column: "Item_Id",
                principalTable: "ITEMS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ITEM_PHOTOES_ITEMS_Item_Id",
                table: "ITEM_PHOTOES",
                column: "Item_Id",
                principalTable: "ITEMS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITEM_DETAILS_ITEMS_Item_Id",
                table: "ITEM_DETAILS");

            migrationBuilder.DropForeignKey(
                name: "FK_ITEM_PHOTOES_ITEMS_Item_Id",
                table: "ITEM_PHOTOES");

            migrationBuilder.DropIndex(
                name: "IX_ITEM_PHOTOES_Item_Id",
                table: "ITEM_PHOTOES");

            migrationBuilder.DropIndex(
                name: "IX_ITEM_DETAILS_Item_Id",
                table: "ITEM_DETAILS");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29450fcf-393d-46db-9b7c-13163fa9a613");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0351938-a6cd-46d7-8df2-f9a7e2563ac2");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "ITEM_PHOTOES",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "ITEM_DETAILS",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "620aee91-2abd-4392-8042-733526803f5c", "72d2d385-18ac-4f6e-a7ce-3cdc7b627bf1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7fefc7f6-dbef-4038-b0d5-1891ef357325", "63d36863-cd5a-4eb3-a010-bc7cc5ee7f32", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_ITEM_DETAILS_ITEMS_Id",
                table: "ITEM_DETAILS",
                column: "Id",
                principalTable: "ITEMS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ITEM_PHOTOES_ITEMS_Id",
                table: "ITEM_PHOTOES",
                column: "Id",
                principalTable: "ITEMS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
