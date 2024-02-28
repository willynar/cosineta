using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class mdfnotmappedtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StarTime",
                table: "OrderProductFeactures",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "OrderProductFeactures",
                newName: "CreationDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicationEndTime",
                table: "ProductSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicationStarTime",
                table: "ProductSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ProductSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductFeaturesDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ProductFeaturesDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductFeatures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ProductFeatures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCategorys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ProductCategorys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderProductFeactureDetailId",
                table: "OrderProductFeactures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "OrderProductFeactureDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "OrderProductFeactureDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StarTime",
                table: "OrderProductFeactureDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "OrderProductFeactureDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "AspNetUsers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TokenFacebook",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TokenGoogle",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TokenOutlook",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TypeId",
                table: "Reviews",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSchedules_ProductId",
                table: "ProductSchedules",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ApplicationUserId",
                table: "Products",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeaturesDetails_ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails",
                column: "ProductFeaturesIdNavigationProductFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeaturesDetails_ProductId",
                table: "ProductFeaturesDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategorys_CategoryId",
                table: "ProductCategorys",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategorys_ProductId",
                table: "ProductCategorys",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactures_OrderProductFeactureDetailId",
                table: "OrderProductFeactures",
                column: "OrderProductFeactureDetailId");

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
                name: "FK_OrderProductFeactures_OrderProductFeactureDetails_OrderProductFeactureDetailId",
                table: "OrderProductFeactures",
                column: "OrderProductFeactureDetailId",
                principalTable: "OrderProductFeactureDetails",
                principalColumn: "OrderProductFeactureDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactures_ProductFeatures_ProductFeatureId",
                table: "OrderProductFeactures",
                column: "ProductFeatureId",
                principalTable: "ProductFeatures",
                principalColumn: "ProductFeatureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategorys_Categories_CategoryId",
                table: "ProductCategorys",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategorys_Products_ProductId",
                table: "ProductCategorys",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeaturesDetails_ProductFeatures_ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails",
                column: "ProductFeaturesIdNavigationProductFeatureId",
                principalTable: "ProductFeatures",
                principalColumn: "ProductFeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFeaturesDetails_Products_ProductId",
                table: "ProductFeaturesDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSchedules_Products_ProductId",
                table: "ProductSchedules",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Types_TypeId",
                table: "Reviews",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactureDetails_ProductFeatures_ProductFeatureId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactureDetails_Products_ProductId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactures_OrderProductFeactureDetails_OrderProductFeactureDetailId",
                table: "OrderProductFeactures");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactures_ProductFeatures_ProductFeatureId",
                table: "OrderProductFeactures");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategorys_Categories_CategoryId",
                table: "ProductCategorys");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategorys_Products_ProductId",
                table: "ProductCategorys");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeaturesDetails_ProductFeatures_ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFeaturesDetails_Products_ProductId",
                table: "ProductFeaturesDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSchedules_Products_ProductId",
                table: "ProductSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Types_TypeId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_TypeId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_ProductSchedules_ProductId",
                table: "ProductSchedules");

            migrationBuilder.DropIndex(
                name: "IX_Products_ApplicationUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductFeaturesDetails_ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductFeaturesDetails_ProductId",
                table: "ProductFeaturesDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategorys_CategoryId",
                table: "ProductCategorys");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategorys_ProductId",
                table: "ProductCategorys");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductFeactures_OrderProductFeactureDetailId",
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

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductSchedules");

            migrationBuilder.DropColumn(
                name: "PublicationEndTime",
                table: "ProductSchedules");

            migrationBuilder.DropColumn(
                name: "PublicationStarTime",
                table: "ProductSchedules");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ProductSchedules");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductFeaturesDetails");

            migrationBuilder.DropColumn(
                name: "ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ProductFeaturesDetails");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductFeatures");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ProductFeatures");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductCategorys");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ProductCategorys");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderProductFeactureDetailId",
                table: "OrderProductFeactures");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropColumn(
                name: "StarTime",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TokenFacebook",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TokenGoogle",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TokenOutlook",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "OrderProductFeactures",
                newName: "StarTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "OrderProductFeactures",
                newName: "EndTime");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
