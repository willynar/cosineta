using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class addnewtablesOFPM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_ApplicationUserId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "ProductsReviews");

            migrationBuilder.RenameColumn(
                name: "IdDeliveryManReview",
                table: "Reviews",
                newName: "ReviewId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalOrder = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityOfProducts = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPaymentMethods",
                columns: table => new
                {
                    UserPaymentMethodsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bin = table.Column<int>(type: "int", nullable: false),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPaymentMethods", x => x.UserPaymentMethodsId);
                    table.ForeignKey(
                        name: "FK_UserPaymentMethods_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProductFeactureDetails",
                columns: table => new
                {
                    OrderProductFeactureDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderIdNavigationOrderId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductIdNavigationProductId = table.Column<int>(type: "int", nullable: true),
                    ProductFeatureId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductFeatureIdNavigationFeaturesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProductFeactureDetails", x => x.OrderProductFeactureDetailId);
                    table.ForeignKey(
                        name: "FK_OrderProductFeactureDetails_Orders_OrderIdNavigationOrderId",
                        column: x => x.OrderIdNavigationOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_OrderProductFeactureDetails_Products_ProductIdNavigationProductId",
                        column: x => x.ProductIdNavigationProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "ProductFeatures",
                columns: table => new
                {
                    FeaturesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MultipleSelection = table.Column<bool>(type: "bit", nullable: false),
                    IsAdditional = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderProductFeactureDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeatures", x => x.FeaturesId);
                    table.ForeignKey(
                        name: "FK_ProductFeatures_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductFeatures_OrderProductFeactureDetails_OrderProductFeactureDetailId",
                        column: x => x.OrderProductFeactureDetailId,
                        principalTable: "OrderProductFeactureDetails",
                        principalColumn: "OrderProductFeactureDetailId");
                });

            migrationBuilder.CreateTable(
                name: "ProductFeaturesDetails",
                columns: table => new
                {
                    ProductFeaturesDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductFeaturesId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductFeaturesIdNavigationFeaturesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeaturesDetails", x => x.ProductFeaturesDetailId);
                    table.ForeignKey(
                        name: "FK_ProductFeaturesDetails_ProductFeatures_ProductFeaturesIdNavigationFeaturesId",
                        column: x => x.ProductFeaturesIdNavigationFeaturesId,
                        principalTable: "ProductFeatures",
                        principalColumn: "FeaturesId");
                    table.ForeignKey(
                        name: "FK_ProductFeaturesDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactureDetails_OrderIdNavigationOrderId",
                table: "OrderProductFeactureDetails",
                column: "OrderIdNavigationOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactureDetails_ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeactureDetails",
                column: "ProductFeatureIdNavigationFeaturesId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactureDetails_ProductIdNavigationProductId",
                table: "OrderProductFeactureDetails",
                column: "ProductIdNavigationProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ApplicationUserId",
                table: "Orders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_ApplicationUserId",
                table: "ProductFeatures",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_OrderProductFeactureDetailId",
                table: "ProductFeatures",
                column: "OrderProductFeactureDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeaturesDetails_ProductFeaturesIdNavigationFeaturesId",
                table: "ProductFeaturesDetails",
                column: "ProductFeaturesIdNavigationFeaturesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeaturesDetails_ProductId",
                table: "ProductFeaturesDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentMethods_ApplicationUserId",
                table: "UserPaymentMethods",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ApplicationUserId",
                table: "Reviews",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactureDetails_ProductFeatures_ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeactureDetails",
                column: "ProductFeatureIdNavigationFeaturesId",
                principalTable: "ProductFeatures",
                principalColumn: "FeaturesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_ApplicationUserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactureDetails_Orders_OrderIdNavigationOrderId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactureDetails_ProductFeatures_ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropTable(
                name: "ProductFeaturesDetails");

            migrationBuilder.DropTable(
                name: "UserPaymentMethods");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "OrderProductFeactureDetails");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Reviews",
                newName: "IdDeliveryManReview");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProductsReviews",
                columns: table => new
                {
                    IdProductReview = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsReviews", x => x.IdProductReview);
                    table.ForeignKey(
                        name: "FK_ProductsReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsReviews_ProductId",
                table: "ProductsReviews",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ApplicationUserId",
                table: "Reviews",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
