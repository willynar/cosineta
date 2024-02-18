using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class mdfproductfeactureids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeaturesDetails_ProductFeatures_ProductFeaturesIdNavigationFeaturesId",
                table: "ProductFeaturesDetails");

            migrationBuilder.RenameColumn(
                name: "ProductFeaturesIdNavigationFeaturesId",
                table: "ProductFeaturesDetails",
                newName: "ProductFeaturesIdNavigationProductFeatureId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFeaturesDetails_ProductFeaturesIdNavigationFeaturesId",
                table: "ProductFeaturesDetails",
                newName: "IX_ProductFeaturesDetails_ProductFeaturesIdNavigationProductFeatureId");

            migrationBuilder.RenameColumn(
                name: "FeaturesId",
                table: "ProductFeatures",
                newName: "ProductFeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeaturesDetails_ProductFeatures_ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails",
                column: "ProductFeaturesIdNavigationProductFeatureId",
                principalTable: "ProductFeatures",
                principalColumn: "ProductFeatureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeaturesDetails_ProductFeatures_ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails");

            migrationBuilder.RenameColumn(
                name: "ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails",
                newName: "ProductFeaturesIdNavigationFeaturesId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductFeaturesDetails_ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails",
                newName: "IX_ProductFeaturesDetails_ProductFeaturesIdNavigationFeaturesId");

            migrationBuilder.RenameColumn(
                name: "ProductFeatureId",
                table: "ProductFeatures",
                newName: "FeaturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeaturesDetails_ProductFeatures_ProductFeaturesIdNavigationFeaturesId",
                table: "ProductFeaturesDetails",
                column: "ProductFeaturesIdNavigationFeaturesId",
                principalTable: "ProductFeatures",
                principalColumn: "FeaturesId");
        }
    }
}
