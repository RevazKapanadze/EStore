using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStore.Migrations
{
  public partial class initial : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "ITEMS",
          columns: table => new
          {
            Id = table.Column<long>(type: "bigint", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Short_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Short_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            Quantity = table.Column<int>(type: "int", nullable: false),
            Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Main_Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
            Company_Id = table.Column<int>(type: "int", nullable: false),
            Is_Active = table.Column<int>(type: "int", nullable: false),
            Main_Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ITEMS", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "ITEM_DETAILS",
          columns: table => new
          {
            Id = table.Column<long>(type: "bigint", nullable: false)
           // .Annotation("SqlServer:Identity", "1, 1")
           ,
            Item_Id = table.Column<long>(type: "bigint", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ITEM_DETAILS", x => x.Id);
            table.ForeignKey(
                      name: "FK_ITEM_DETAILS_ITEMS_Id",
                      column: x => x.Id,
                      principalTable: "ITEMS",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "ITEM_PHOTOES",
          columns: table => new
          {
            Id = table.Column<long>(type: "bigint", nullable: false)
           // .Annotation("SqlServer:Identity", "1, 1")
           ,
            Item_Id = table.Column<long>(type: "bigint", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ITEM_PHOTOES", x => x.Id);
            table.ForeignKey(
                      name: "FK_ITEM_PHOTOES_ITEMS_Id",
                      column: x => x.Id,
                      principalTable: "ITEMS",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "ITEM_DETAILS");

      migrationBuilder.DropTable(
          name: "ITEM_PHOTOES");

      migrationBuilder.DropTable(
          name: "ITEMS");
    }
  }
}
