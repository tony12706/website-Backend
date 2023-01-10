using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneAPI.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Register",
                columns: table => new
                {
                    EmailId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MobNo = table.Column<long>(type: "bigint", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ResidenceAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SecurityQuestion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SecurityAnswer = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Register", x => x.EmailId);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNo = table.Column<long>(type: "bigint", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PinCode = table.Column<int>(type: "int", nullable: false),
                    AddrType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddrId);
                    table.ForeignKey(
                        name: "FK_Address_Register_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Register",
                        principalColumn: "EmailId");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailId = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SellerEmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductBrand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ShippingCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Cart_Register_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Register",
                        principalColumn: "EmailId");
                });

            migrationBuilder.CreateTable(
                name: "DeliveryPincode",
                columns: table => new
                {
                    PId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PinCode = table.Column<int>(type: "int", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPincode", x => x.PId);
                    table.ForeignKey(
                        name: "FK_DeliveryPincode_Register_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Register",
                        principalColumn: "EmailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailId = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SellerEmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductBrand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ShippingCost = table.Column<int>(type: "int", nullable: false),
                    QuantityPurchased = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    DeliveryStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Register_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Register",
                        principalColumn: "EmailId");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailId = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ProductType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductBrand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditonalProductImage1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditonalProductImage2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ShippingCost = table.Column<int>(type: "int", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    NoOfRatings = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Register_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Register",
                        principalColumn: "EmailId");
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    WishListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailId = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SellerEmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductBrand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ShippingCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.WishListId);
                    table.ForeignKey(
                        name: "FK_Wishlist_Register_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Register",
                        principalColumn: "EmailId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_EmailId",
                table: "Address",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_EmailId",
                table: "Cart",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryPincode_EmailId",
                table: "DeliveryPincode",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmailId",
                table: "Order",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_EmailId",
                table: "Product",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_EmailId",
                table: "Wishlist",
                column: "EmailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "DeliveryPincode");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "Register");
        }
    }
}
