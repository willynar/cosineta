using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class updprductmodels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeaturesDetails_ProductFeatures_ProductFeatureId",
                table: "ProductFeaturesDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductFeaturesDetails_ProductFeatureId",
                table: "ProductFeaturesDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductFeaturesDetails_ProductFeatureId",
                table: "ProductFeaturesDetails",
                column: "ProductFeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeaturesDetails_ProductFeatures_ProductFeatureId",
                table: "ProductFeaturesDetails",
                column: "ProductFeatureId",
                principalTable: "ProductFeatures",
                principalColumn: "ProductFeatureId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
