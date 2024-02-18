using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class correctionOFPM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeatures_OrderProductFeactureDetails_OrderProductFeactureDetailId",
                table: "ProductFeatures");

            migrationBuilder.DropIndex(
                name: "IX_ProductFeatures_OrderProductFeactureDetailId",
                table: "ProductFeatures");

            migrationBuilder.DropColumn(
                name: "OrderProductFeactureDetailId",
                table: "ProductFeatures");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "ProductFeatures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "OrderProductFeacture",
                columns: table => new
                {
                    OrderProductFeactureIs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductFeatureId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductFeatureIdNavigationFeaturesId = table.Column<int>(type: "int", nullable: true),
                    OrderProductFeactureDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProductFeacture", x => x.OrderProductFeactureIs);
                    table.ForeignKey(
                        name: "FK_OrderProductFeacture_OrderProductFeactureDetails_OrderProductFeactureDetailId",
                        column: x => x.OrderProductFeactureDetailId,
                        principalTable: "OrderProductFeactureDetails",
                        principalColumn: "OrderProductFeactureDetailId");
                    table.ForeignKey(
                        name: "FK_OrderProductFeacture_ProductFeatures_ProductFeatureIdNavigationFeaturesId",
                        column: x => x.ProductFeatureIdNavigationFeaturesId,
                        principalTable: "ProductFeatures",
                        principalColumn: "FeaturesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeacture_OrderProductFeactureDetailId",
                table: "OrderProductFeacture",
                column: "OrderProductFeactureDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeacture_ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeacture",
                column: "ProductFeatureIdNavigationFeaturesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProductFeacture");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "ProductFeatures");

            migrationBuilder.AddColumn<int>(
                name: "OrderProductFeactureDetailId",
                table: "ProductFeatures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_OrderProductFeactureDetailId",
                table: "ProductFeatures",
                column: "OrderProductFeactureDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeatures_OrderProductFeactureDetails_OrderProductFeactureDetailId",
                table: "ProductFeatures",
                column: "OrderProductFeactureDetailId",
                principalTable: "OrderProductFeactureDetails",
                principalColumn: "OrderProductFeactureDetailId");
        }
    }
}
