using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class addtableOPF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeacture_OrderProductFeactureDetails_OrderProductFeactureDetailId",
                table: "OrderProductFeacture");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeacture_ProductFeatures_ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeacture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProductFeacture",
                table: "OrderProductFeacture");

            migrationBuilder.RenameTable(
                name: "OrderProductFeacture",
                newName: "OrderProductFeactures");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProductFeacture_ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeactures",
                newName: "IX_OrderProductFeactures_ProductFeatureIdNavigationFeaturesId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProductFeacture_OrderProductFeactureDetailId",
                table: "OrderProductFeactures",
                newName: "IX_OrderProductFeactures_OrderProductFeactureDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProductFeactures",
                table: "OrderProductFeactures",
                column: "OrderProductFeactureIs");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactures_OrderProductFeactureDetails_OrderProductFeactureDetailId",
                table: "OrderProductFeactures",
                column: "OrderProductFeactureDetailId",
                principalTable: "OrderProductFeactureDetails",
                principalColumn: "OrderProductFeactureDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactures_ProductFeatures_ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeactures",
                column: "ProductFeatureIdNavigationFeaturesId",
                principalTable: "ProductFeatures",
                principalColumn: "FeaturesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactures_OrderProductFeactureDetails_OrderProductFeactureDetailId",
                table: "OrderProductFeactures");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactures_ProductFeatures_ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeactures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProductFeactures",
                table: "OrderProductFeactures");

            migrationBuilder.RenameTable(
                name: "OrderProductFeactures",
                newName: "OrderProductFeacture");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProductFeactures_ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeacture",
                newName: "IX_OrderProductFeacture_ProductFeatureIdNavigationFeaturesId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProductFeactures_OrderProductFeactureDetailId",
                table: "OrderProductFeacture",
                newName: "IX_OrderProductFeacture_OrderProductFeactureDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProductFeacture",
                table: "OrderProductFeacture",
                column: "OrderProductFeactureIs");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeacture_OrderProductFeactureDetails_OrderProductFeactureDetailId",
                table: "OrderProductFeacture",
                column: "OrderProductFeactureDetailId",
                principalTable: "OrderProductFeactureDetails",
                principalColumn: "OrderProductFeactureDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeacture_ProductFeatures_ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeacture",
                column: "ProductFeatureIdNavigationFeaturesId",
                principalTable: "ProductFeatures",
                principalColumn: "FeaturesId");
        }
    }
}
