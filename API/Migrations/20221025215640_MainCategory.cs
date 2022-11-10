using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStore.Migrations
{
    public partial class MainCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITEMS_company_Company_Id",
                table: "ITEMS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_company",
                table: "company");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "ITEMS");

            migrationBuilder.RenameTable(
                name: "company",
                newName: "COMPANY");

            migrationBuilder.AddColumn<int>(
                name: "Category_Id",
                table: "ITEMS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_COMPANY",
                table: "COMPANY",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MAINCATEGORY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAINCATEGORY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mainCategory_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CATEGORY_MAINCATEGORY_mainCategory_Id",
                        column: x => x.mainCategory_Id,
                        principalTable: "MAINCATEGORY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITEMS_Category_Id",
                table: "ITEMS",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORY_mainCategory_Id",
                table: "CATEGORY",
                column: "mainCategory_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ITEMS_CATEGORY_Category_Id",
                table: "ITEMS",
                column: "Category_Id",
                principalTable: "CATEGORY",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ITEMS_COMPANY_Company_Id",
                table: "ITEMS",
                column: "Company_Id",
                principalTable: "COMPANY",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITEMS_CATEGORY_Category_Id",
                table: "ITEMS");

            migrationBuilder.DropForeignKey(
                name: "FK_ITEMS_COMPANY_Company_Id",
                table: "ITEMS");

            migrationBuilder.DropTable(
                name: "CATEGORY");

            migrationBuilder.DropTable(
                name: "MAINCATEGORY");

            migrationBuilder.DropIndex(
                name: "IX_ITEMS_Category_Id",
                table: "ITEMS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_COMPANY",
                table: "COMPANY");

            migrationBuilder.DropColumn(
                name: "Category_Id",
                table: "ITEMS");

            migrationBuilder.RenameTable(
                name: "COMPANY",
                newName: "company");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ITEMS",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_company",
                table: "company",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ITEMS_company_Company_Id",
                table: "ITEMS",
                column: "Company_Id",
                principalTable: "company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
