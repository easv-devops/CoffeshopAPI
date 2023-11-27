using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Additions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Addition__3214EC078AF931A3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brewing_methods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Brewing___3214EC0753A8E88B", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coffee_beans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Coffee_b__3214EC077DFE8327", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pickup_locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    shopName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pickup_l__3214EC0720E6FDBC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Predefined_coffees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Predefin__3214EC0734C7AEE4", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<byte[]>(type: "varbinary(256)", maxLength: 256, nullable: false),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false),
                    firstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3214EC07DEDEE4A0", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Custom_coffees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    beanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    brewingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    totalPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Custom_c__3214EC07865FB1CC", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Custom_co__beanI__5BE2A6F2",
                        column: x => x.beanId,
                        principalTable: "Coffee_beans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Custom_co__brewi__5CD6CB2B",
                        column: x => x.brewingId,
                        principalTable: "Brewing_methods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cookies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    predefinedCoffeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cookies__3214EC07FB0FC4F6", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Cookies__predefi__71D1E811",
                        column: x => x.predefinedCoffeeId,
                        principalTable: "Predefined_coffees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    predefinedCoffeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    commentTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comments__3214EC07E1C848FB", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Comments__predef__693CA210",
                        column: x => x.predefinedCoffeeId,
                        principalTable: "Predefined_coffees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Comments__userId__68487DD7",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    predefinedCoffeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    likeTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Likes__3214EC071C73E7A9", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Likes__predefine__6477ECF3",
                        column: x => x.predefinedCoffeeId,
                        principalTable: "Predefined_coffees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Likes__userId__6383C8BA",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    userId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    locationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    totalPrice = table.Column<decimal>(type: "money", nullable: false),
                    orderTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    pickupTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__3214EC0725A16FD7", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Orders__location__6E01572D",
                        column: x => x.locationId,
                        principalTable: "Pickup_locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Orders__userId__6D0D32F4",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    customCoffeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    additionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Favorite__3214EC07567C5829", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Favorites__addit__7D439ABD",
                        column: x => x.additionId,
                        principalTable: "Additions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Favorites__custo__7C4F7684",
                        column: x => x.customCoffeeId,
                        principalTable: "Custom_coffees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order_details",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    orderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    predefinedCoffeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    customCoffeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    cookieId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order_de__3214EC0768D2A478", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Order_det__cooki__787EE5A0",
                        column: x => x.cookieId,
                        principalTable: "Cookies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Order_det__custo__778AC167",
                        column: x => x.customCoffeeId,
                        principalTable: "Custom_coffees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Order_det__order__75A278F5",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Order_det__prede__76969D2E",
                        column: x => x.predefinedCoffeeId,
                        principalTable: "Predefined_coffees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_predefinedCoffeeId",
                table: "Comments",
                column: "predefinedCoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_userId",
                table: "Comments",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Cookies_predefinedCoffeeId",
                table: "Cookies",
                column: "predefinedCoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Custom_coffees_beanId",
                table: "Custom_coffees",
                column: "beanId");

            migrationBuilder.CreateIndex(
                name: "IX_Custom_coffees_brewingId",
                table: "Custom_coffees",
                column: "brewingId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_additionId",
                table: "Favorites",
                column: "additionId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_customCoffeeId",
                table: "Favorites",
                column: "customCoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_predefinedCoffeeId",
                table: "Likes",
                column: "predefinedCoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_userId",
                table: "Likes",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_details_cookieId",
                table: "Order_details",
                column: "cookieId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_details_customCoffeeId",
                table: "Order_details",
                column: "customCoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_details_orderId",
                table: "Order_details",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_details_predefinedCoffeeId",
                table: "Order_details",
                column: "predefinedCoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_locationId",
                table: "Orders",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userId",
                table: "Orders",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__AB6E61645FBED559",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__F3DBC5726B993205",
                table: "Users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Order_details");

            migrationBuilder.DropTable(
                name: "Additions");

            migrationBuilder.DropTable(
                name: "Cookies");

            migrationBuilder.DropTable(
                name: "Custom_coffees");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Predefined_coffees");

            migrationBuilder.DropTable(
                name: "Coffee_beans");

            migrationBuilder.DropTable(
                name: "Brewing_methods");

            migrationBuilder.DropTable(
                name: "Pickup_locations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
