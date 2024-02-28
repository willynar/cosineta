using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class mdfrelationsorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactureDetails_ProductFeatures_ProductFeatureId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactureDetails_Products_ProductId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactures_ProductFeatures_ProductFeatureId",
                table: "OrderProductFeactures");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductFeactures_ProductFeatureId",
                table: "OrderProductFeactures");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductFeactureDetails_ProductFeatureId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductFeactureDetails_ProductId",
                table: "OrderProductFeactureDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactures_ProductFeatureId",
                table: "OrderProductFeactures",
                column: "ProductFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactureDetails_ProductFeatureId",
                table: "OrderProductFeactureDetails",
                column: "ProductFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactureDetails_ProductId",
                table: "OrderProductFeactureDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactureDetails_ProductFeatures_ProductFeatureId",
                table: "OrderProductFeactureDetails",
                column: "ProductFeatureId",
                principalTable: "ProductFeatures",
                principalColumn: "ProductFeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactureDetails_Products_ProductId",
                table: "OrderProductFeactureDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactures_ProductFeatures_ProductFeatureId",
                table: "OrderProductFeactures",
                column: "ProductFeatureId",
                principalTable: "ProductFeatures",
                principalColumn: "ProductFeatureId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
