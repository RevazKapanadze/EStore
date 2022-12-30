using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStore.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BASKETS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASKETS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COMPANY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_Logo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    Company_Id = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_COMPANY_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "COMPANY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_Id = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAdress_FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAdress_Adress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAdress_Google_Map = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAdress_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAdress_State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAdress_Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAdress_EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubTotal = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryFee = table.Column<long>(type: "bigint", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORDERS_COMPANY_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "COMPANY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userAdress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Google_Map = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAdress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userAdress_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemOrdered_ItemId = table.Column<int>(type: "int", nullable: true),
                    ItemOrdered_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemOrdered_PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderItem_ORDERS_orderId",
                        column: x => x.orderId,
                        principalTable: "ORDERS",
                        principalColumn: "Id");
                });

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
                    Main_Category = table.Column<int>(type: "int", nullable: false),
                    Is_Active = table.Column<int>(type: "int", nullable: false),
                    Main_Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category_Id = table.Column<int>(type: "int", nullable: false),
                    Company_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ITEMS_CATEGORY_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "CATEGORY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ITEMS_COMPANY_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "COMPANY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BASKET_ITEMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    BasketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BASKET_ITEMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BASKET_ITEMS_BASKETS_BasketId",
                        column: x => x.BasketId,
                        principalTable: "BASKETS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BASKET_ITEMS_ITEMS_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ITEMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ITEM_DETAILS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Sale = table.Column<int>(type: "int", nullable: false),
                    Item_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEM_DETAILS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ITEM_DETAILS_ITEMS_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "ITEMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ITEM_PHOTOES",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Item_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITEM_PHOTOES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ITEM_PHOTOES_ITEMS_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "ITEMS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "165e27fe-6f39-4cd2-933d-736854997506", "User", "USER" },
                    { 2, "15a3c463-f191-469a-b1b2-24212fbb23f4", "Admin", "ADMIN" },
                    { 3, "f8f4c345-21db-493d-8927-de85186dd7d7", "Peasant", "PEASANT" }
                });

            migrationBuilder.InsertData(
                table: "COMPANY",
                columns: new[] { "Id", "Company_Logo", "Details", "Name" },
                values: new object[] { 1, "data:image/png;base64,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", "საქართველოს ბანკის ჯგუფი (Bank of Georgia Group PLC, „საქართველოს ბანკის ჯგუფი“, ჯგუფი, ან „BOGG“, ლონდონის საფონდო ბირჟაზე: BGEO:LN) — გაერთიანებულ სამეფოში დაფუძნებული ჰოლდინგური კომპანია,[1] რომელიც BGEO Group PLC-ს (BGEO) ახალ მშობელ კომპანიას წარმოადგენს. 2018 წლის 29 მაისამდე BGEO, როგორც საქართველოს ერთ-ერთი უმსხვილესი საინვესტიციო ჯგუფი, საბანკო ბიზნესსა და საინვესტიციო ბიზნესს აერთიანებდა.", "საქ ბანკი" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Company_Id",
                table: "AspNetUsers",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BASKET_ITEMS_BasketId",
                table: "BASKET_ITEMS",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BASKET_ITEMS_ProductId",
                table: "BASKET_ITEMS",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORY_mainCategory_Id",
                table: "CATEGORY",
                column: "mainCategory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ITEM_DETAILS_Item_Id",
                table: "ITEM_DETAILS",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ITEM_PHOTOES_Item_Id",
                table: "ITEM_PHOTOES",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ITEMS_Category_Id",
                table: "ITEMS",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ITEMS_Company_Id",
                table: "ITEMS",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_orderItem_orderId",
                table: "orderItem",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_Company_Id",
                table: "ORDERS",
                column: "Company_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BASKET_ITEMS");

            migrationBuilder.DropTable(
                name: "ITEM_DETAILS");

            migrationBuilder.DropTable(
                name: "ITEM_PHOTOES");

            migrationBuilder.DropTable(
                name: "orderItem");

            migrationBuilder.DropTable(
                name: "userAdress");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BASKETS");

            migrationBuilder.DropTable(
                name: "ITEMS");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CATEGORY");

            migrationBuilder.DropTable(
                name: "COMPANY");

            migrationBuilder.DropTable(
                name: "MAINCATEGORY");
        }
    }
}
