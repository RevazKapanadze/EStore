using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStore.Migrations
{
  public partial class itemsavailable : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {/*
         migrationBuilder.AddColumn<string>(
             name: "Available_Colors",
             table: "ITEMS",
             type: "nvarchar(max)",
             nullable: true);

         migrationBuilder.AddColumn<string>(
             name: "Available_Sizes",
             table: "ITEMS",
             type: "nvarchar(max)",
             nullable: true);*/
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      /*
    migrationBuilder.DropColumn(
            name: "Available_Colors",
            table: "ITEMS");

      migrationBuilder.DropColumn(
          name: "Available_Sizes",
          table: "ITEMS");*/
    }
  }
}
