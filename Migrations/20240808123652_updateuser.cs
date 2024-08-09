using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationStore.Migrations
{
    public partial class updateuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Family",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BdCountry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdCountry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BdPaymentStatusType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdPaymentStatusType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BdSendStatusType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdSendStatusType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BdShoppingBasketType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdShoppingBasketType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BdSizeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdSizeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BdTax",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxPercentage = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdTax", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IsLocked = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScAdmin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScAdmin_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SdCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SdColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdColor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SdCoupon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CouponPercent = table.Column<int>(type: "int", nullable: true),
                    MaxRialValue = table.Column<int>(type: "int", nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdCoupon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SdProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BdState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BdState_BdCountry_CountryId",
                        column: x => x.CountryId,
                        principalTable: "BdCountry",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SdShoppingBasket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdShoppingBasket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SdShoppingBasket_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SdShoppingBasket_BdShoppingBasketType_StatusId",
                        column: x => x.StatusId,
                        principalTable: "BdShoppingBasketType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SdProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SdProductCategory_SdCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SdCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SdProductCategory_SdProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "SdProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SdProductCharge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    SaleTaxId = table.Column<int>(type: "int", nullable: true),
                    BuyInvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BuyPrice = table.Column<int>(type: "int", nullable: true),
                    BuyCount = table.Column<int>(type: "int", nullable: true),
                    PercentInterest = table.Column<int>(type: "int", nullable: true),
                    PercentWages = table.Column<int>(type: "int", nullable: true),
                    Idddl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdProductCharge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SdProductCharge_BdTax_SaleTaxId",
                        column: x => x.SaleTaxId,
                        principalTable: "BdTax",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SdProductCharge_SdProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "SdProduct",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BdCity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdCity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BdCity_BdState_StateId",
                        column: x => x.StateId,
                        principalTable: "BdState",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BdSendBoxPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdSendBoxPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BdSendBoxPrice_BdState_StateId",
                        column: x => x.StateId,
                        principalTable: "BdState",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BdSendProductsPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdSendProductsPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BdSendProductsPrice_BdState_StateId",
                        column: x => x.StateId,
                        principalTable: "BdState",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BdSendProductsPrice_SdProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "SdProduct",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SdTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingBasketId = table.Column<int>(type: "int", nullable: true),
                    SumTaxAmount = table.Column<int>(type: "int", nullable: true),
                    DiscountCodeId = table.Column<int>(type: "int", nullable: true),
                    DiscountAmount = table.Column<int>(type: "int", nullable: true),
                    SendAmount = table.Column<int>(type: "int", nullable: true),
                    SumShoppingBasketPrice = table.Column<int>(type: "int", nullable: true),
                    SumShoppingBasketDiscount = table.Column<int>(type: "int", nullable: true),
                    AmountForPay = table.Column<int>(type: "int", nullable: true),
                    PaymentStatusId = table.Column<int>(type: "int", nullable: true),
                    PaymentTrackingNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SdTransaction_BdPaymentStatusType_PaymentStatusId",
                        column: x => x.PaymentStatusId,
                        principalTable: "BdPaymentStatusType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SdTransaction_SdCoupon_DiscountCodeId",
                        column: x => x.DiscountCodeId,
                        principalTable: "SdCoupon",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SdTransaction_SdShoppingBasket_ShoppingBasketId",
                        column: x => x.ShoppingBasketId,
                        principalTable: "SdShoppingBasket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SdProductChargesProperty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductChargeId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    RemainingCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdProductChargesProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SdProductChargesProperty_SdColor_ColorId",
                        column: x => x.ColorId,
                        principalTable: "SdColor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SdProductChargesProperty_SdProductCharge_ProductChargeId",
                        column: x => x.ProductChargeId,
                        principalTable: "SdProductCharge",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SdAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SdAddress_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SdAddress_BdCity_CityId",
                        column: x => x.CityId,
                        principalTable: "BdCity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SdSendBox",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingBasketId = table.Column<int>(type: "int", nullable: true),
                    TransactionId = table.Column<int>(type: "int", nullable: true),
                    SendPriceId = table.Column<int>(type: "int", nullable: true),
                    SendTypeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SendStatusId = table.Column<int>(type: "int", nullable: true),
                    SendTrackingNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdSendBox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SdSendBox_BdCity_CityId",
                        column: x => x.CityId,
                        principalTable: "BdCity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SdSendBox_BdSendBoxPrice_SendPriceId",
                        column: x => x.SendPriceId,
                        principalTable: "BdSendBoxPrice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SdSendBox_BdSendStatusType_SendStatusId",
                        column: x => x.SendStatusId,
                        principalTable: "BdSendStatusType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SdSendBox_SdShoppingBasket_ShoppingBasketId",
                        column: x => x.ShoppingBasketId,
                        principalTable: "SdShoppingBasket",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SdSendBox_SdTransaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "SdTransaction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SdImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductChargePropertiesId = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SdImage_SdProductChargesProperty_ProductChargePropertiesId",
                        column: x => x.ProductChargePropertiesId,
                        principalTable: "SdProductChargesProperty",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SdProductSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    ProductChargePropertiesId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdProductSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SdProductSize_BdSizeType_SizeId",
                        column: x => x.SizeId,
                        principalTable: "BdSizeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SdProductSize_SdProductChargesProperty_ProductChargePropertiesId",
                        column: x => x.ProductChargePropertiesId,
                        principalTable: "SdProductChargesProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SdShoppingBasketObject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingBasketId = table.Column<int>(type: "int", nullable: false),
                    ProductChargePropertiesId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: true),
                    OldPrice = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdShoppingBasketObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SdShoppingBasketObject_SdProductChargesProperty_ProductChargePropertiesId",
                        column: x => x.ProductChargePropertiesId,
                        principalTable: "SdProductChargesProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SdShoppingBasketObject_SdShoppingBasket_ShoppingBasketId",
                        column: x => x.ShoppingBasketId,
                        principalTable: "SdShoppingBasket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SdVote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductChargePropertiesId = table.Column<int>(type: "int", nullable: false),
                    Star = table.Column<byte>(type: "tinyint", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SdVote_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SdVote_SdProductChargesProperty_ProductChargePropertiesId",
                        column: x => x.ProductChargePropertiesId,
                        principalTable: "SdProductChargesProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BdCity_StateId",
                table: "BdCity",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_BdSendBoxPrice_StateId",
                table: "BdSendBoxPrice",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_BdSendProductsPrice_ProductId",
                table: "BdSendProductsPrice",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BdSendProductsPrice_StateId",
                table: "BdSendProductsPrice",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_BdState_CountryId",
                table: "BdState",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ScAdmin_UserId1",
                table: "ScAdmin",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_SdAddress_CityId",
                table: "SdAddress",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_SdAddress_UserId1",
                table: "SdAddress",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_SdImage_ProductChargePropertiesId",
                table: "SdImage",
                column: "ProductChargePropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_SdProductCategory_CategoryId",
                table: "SdProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SdProductCategory_ProductId",
                table: "SdProductCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SdProductCharge_ProductId",
                table: "SdProductCharge",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SdProductCharge_SaleTaxId",
                table: "SdProductCharge",
                column: "SaleTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_SdProductChargesProperty_ColorId",
                table: "SdProductChargesProperty",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_SdProductChargesProperty_ProductChargeId",
                table: "SdProductChargesProperty",
                column: "ProductChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_SdProductSize_ProductChargePropertiesId",
                table: "SdProductSize",
                column: "ProductChargePropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_SdProductSize_SizeId",
                table: "SdProductSize",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_SdSendBox_CityId",
                table: "SdSendBox",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_SdSendBox_SendPriceId",
                table: "SdSendBox",
                column: "SendPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_SdSendBox_SendStatusId",
                table: "SdSendBox",
                column: "SendStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SdSendBox_ShoppingBasketId",
                table: "SdSendBox",
                column: "ShoppingBasketId");

            migrationBuilder.CreateIndex(
                name: "IX_SdSendBox_TransactionId",
                table: "SdSendBox",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_SdShoppingBasket_StatusId",
                table: "SdShoppingBasket",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SdShoppingBasket_UserId1",
                table: "SdShoppingBasket",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_SdShoppingBasketObject_ProductChargePropertiesId",
                table: "SdShoppingBasketObject",
                column: "ProductChargePropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_SdShoppingBasketObject_ShoppingBasketId",
                table: "SdShoppingBasketObject",
                column: "ShoppingBasketId");

            migrationBuilder.CreateIndex(
                name: "IX_SdTransaction_DiscountCodeId",
                table: "SdTransaction",
                column: "DiscountCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SdTransaction_PaymentStatusId",
                table: "SdTransaction",
                column: "PaymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SdTransaction_ShoppingBasketId",
                table: "SdTransaction",
                column: "ShoppingBasketId");

            migrationBuilder.CreateIndex(
                name: "IX_SdVote_ProductChargePropertiesId",
                table: "SdVote",
                column: "ProductChargePropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_SdVote_UserId1",
                table: "SdVote",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BdSendProductsPrice");

            migrationBuilder.DropTable(
                name: "ScAdmin");

            migrationBuilder.DropTable(
                name: "SdAddress");

            migrationBuilder.DropTable(
                name: "SdImage");

            migrationBuilder.DropTable(
                name: "SdProductCategory");

            migrationBuilder.DropTable(
                name: "SdProductSize");

            migrationBuilder.DropTable(
                name: "SdSendBox");

            migrationBuilder.DropTable(
                name: "SdShoppingBasketObject");

            migrationBuilder.DropTable(
                name: "SdVote");

            migrationBuilder.DropTable(
                name: "SdCategory");

            migrationBuilder.DropTable(
                name: "BdSizeType");

            migrationBuilder.DropTable(
                name: "BdCity");

            migrationBuilder.DropTable(
                name: "BdSendBoxPrice");

            migrationBuilder.DropTable(
                name: "BdSendStatusType");

            migrationBuilder.DropTable(
                name: "SdTransaction");

            migrationBuilder.DropTable(
                name: "SdProductChargesProperty");

            migrationBuilder.DropTable(
                name: "BdState");

            migrationBuilder.DropTable(
                name: "BdPaymentStatusType");

            migrationBuilder.DropTable(
                name: "SdCoupon");

            migrationBuilder.DropTable(
                name: "SdShoppingBasket");

            migrationBuilder.DropTable(
                name: "SdColor");

            migrationBuilder.DropTable(
                name: "SdProductCharge");

            migrationBuilder.DropTable(
                name: "BdCountry");

            migrationBuilder.DropTable(
                name: "BdShoppingBasketType");

            migrationBuilder.DropTable(
                name: "BdTax");

            migrationBuilder.DropTable(
                name: "SdProduct");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Family",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }
    }
}
