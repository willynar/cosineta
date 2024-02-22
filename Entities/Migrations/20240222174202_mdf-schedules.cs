using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class mdfschedules : Migration
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
                name: "ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails");

            migrationBuilder.DropColumn(
                name: "OrderProductFeactureDetailId",
                table: "OrderProductFeactures");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Serving",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "OrderProductFeactures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StarTime",
                table: "OrderProductFeactures",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ProductSchedules",
                columns: table => new
                {
                    UserScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StarTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSchedules", x => x.UserScheduleId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSchedules");

            migrationBuilder.DropColumn(
                name: "Serving",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "OrderProductFeactures");

            migrationBuilder.DropColumn(
                name: "StarTime",
                table: "OrderProductFeactures");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ProductFeaturesIdNavigationProductFeatureId",
                table: "ProductFeaturesDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderProductFeactureDetailId",
                table: "OrderProductFeactures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TypeId",
                table: "Reviews",
                column: "TypeId");

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
    }
}
