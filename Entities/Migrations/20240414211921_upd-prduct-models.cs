using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class updprductmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeaturesDetails_ProductFeatures_ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductFeaturesDetails_ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails");

            migrationBuilder.DropColumn(
                name: "ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails");

            migrationBuilder.DropColumn(
                name: "Required",
                table: "ProductFeaturesDetails");

            migrationBuilder.DropColumn(
                name: "IsAdditional",
                table: "ProductFeatures");

            migrationBuilder.DropColumn(
                name: "MultipleSelection",
                table: "ProductFeatures");

            migrationBuilder.RenameColumn(
                name: "ProductFeaturesId",
                table: "ProductFeaturesDetails",
                newName: "ProductFeatureId");

            migrationBuilder.RenameColumn(
                name: "Features",
                table: "ProductFeatures",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "ProductFeactureCategorys",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductFeatures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "ProductFeatures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdditional",
                table: "ProductFeactureCategorys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MultipleSelection",
                table: "ProductFeactureCategorys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductFeactureCategorys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Required",
                table: "ProductFeactureCategorys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeaturesDetails_ProductFeatureId",
                table: "ProductFeaturesDetails",
                column: "ProductFeatureId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ProductFeaturesDetails_ProductFeatures_ProductFeatureId",
            //    table: "ProductFeaturesDetails",
            //    column: "ProductFeatureId",
            //    principalTable: "ProductFeatures",
            //    principalColumn: "ProductFeatureId",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ProductFeaturesDetails_ProductFeatures_ProductFeatureId",
            //    table: "ProductFeaturesDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductFeaturesDetails_ProductFeatureId",
                table: "ProductFeaturesDetails");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductFeatures");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "ProductFeatures");

            migrationBuilder.DropColumn(
                name: "IsAdditional",
                table: "ProductFeactureCategorys");

            migrationBuilder.DropColumn(
                name: "MultipleSelection",
                table: "ProductFeactureCategorys");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductFeactureCategorys");

            migrationBuilder.DropColumn(
                name: "Required",
                table: "ProductFeactureCategorys");

            migrationBuilder.RenameColumn(
                name: "ProductFeatureId",
                table: "ProductFeaturesDetails",
                newName: "ProductFeaturesId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductFeatures",
                newName: "Features");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ProductFeactureCategorys",
                newName: "Category");

            migrationBuilder.AddColumn<int>(
                name: "ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Required",
                table: "ProductFeaturesDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdditional",
                table: "ProductFeatures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MultipleSelection",
                table: "ProductFeatures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeaturesDetails_ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails",
                column: "ProductFeaturesIdNavigationProductFeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeaturesDetails_ProductFeatures_ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails",
                column: "ProductFeaturesIdNavigationProductFeatureId",
                principalTable: "ProductFeatures",
                principalColumn: "ProductFeatureId");
        }
    }
}
