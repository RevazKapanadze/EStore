using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStore.Migrations
{
    public partial class company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ITEMS_Company_Id",
                table: "ITEMS",
                column: "Company_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ITEMS_company_Company_Id",
                table: "ITEMS",
                column: "Company_Id",
                principalTable: "company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITEMS_company_Company_Id",
                table: "ITEMS");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropIndex(
                name: "IX_ITEMS_Company_Id",
                table: "ITEMS");
        }
    }
}
