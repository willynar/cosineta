using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class mdftablesids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Types_TypeIdNavigationTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactureDetails_Orders_OrderIdNavigationOrderId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactureDetails_ProductFeatures_ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactureDetails_Products_ProductIdNavigationProductId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactures_ProductFeatures_ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeactures");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Types_TypeIdNavigationTypeId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_RolLinks_UsersRoles_ApplicationRoleIdNavigationUserRoleId",
                table: "RolLinks");

            migrationBuilder.DropIndex(
                name: "IX_RolLinks_ApplicationRoleIdNavigationUserRoleId",
                table: "RolLinks");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_TypeIdNavigationTypeId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductFeactures_ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeactures");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductFeactureDetails_OrderIdNavigationOrderId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductFeactureDetails_ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductFeactureDetails_ProductIdNavigationProductId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TypeIdNavigationTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationRoleIdNavigationUserRoleId",
                table: "RolLinks");

            migrationBuilder.DropColumn(
                name: "TypeIdNavigationTypeId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeactures");

            migrationBuilder.DropColumn(
                name: "OrderIdNavigationOrderId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropColumn(
                name: "ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropColumn(
                name: "ProductIdNavigationProductId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropColumn(
                name: "TypeIdNavigationTypeId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserRoleId",
                table: "RolLinks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Reviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ProductFeaturesId",
                table: "ProductFeaturesDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ProductFeatureId",
                table: "OrderProductFeactures",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "OrderProductFeactureDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductFeatureId",
                table: "OrderProductFeactureDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderProductFeactureDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_RolLinks_UserRoleId",
                table: "RolLinks",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TypeId",
                table: "Reviews",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactures_ProductFeatureId",
                table: "OrderProductFeactures",
                column: "ProductFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactureDetails_OrderId",
                table: "OrderProductFeactureDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactureDetails_ProductFeatureId",
                table: "OrderProductFeactureDetails",
                column: "ProductFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactureDetails_ProductId",
                table: "OrderProductFeactureDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TypeId",
                table: "AspNetUsers",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Types_TypeId",
                table: "AspNetUsers",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactureDetails_Orders_OrderId",
                table: "OrderProductFeactureDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactureDetails_ProductFeatures_ProductFeatureId",
                table: "OrderProductFeactureDetails",
                column: "ProductFeatureId",
                principalTable: "ProductFeatures",
                principalColumn: "FeaturesId");

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
                principalColumn: "FeaturesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Types_TypeId",
                table: "Reviews",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolLinks_UsersRoles_UserRoleId",
                table: "RolLinks",
                column: "UserRoleId",
                principalTable: "UsersRoles",
                principalColumn: "UserRoleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Types_TypeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactureDetails_Orders_OrderId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactureDetails_ProductFeatures_ProductFeatureId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactureDetails_Products_ProductId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactures_ProductFeatures_ProductFeatureId",
                table: "OrderProductFeactures");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Types_TypeId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_RolLinks_UsersRoles_UserRoleId",
                table: "RolLinks");

            migrationBuilder.DropIndex(
                name: "IX_RolLinks_UserRoleId",
                table: "RolLinks");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_TypeId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductFeactures_ProductFeatureId",
                table: "OrderProductFeactures");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductFeactureDetails_OrderId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductFeactureDetails_ProductFeatureId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductFeactureDetails_ProductId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TypeId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserRoleId",
                table: "RolLinks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationRoleIdNavigationUserRoleId",
                table: "RolLinks",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TypeId",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TypeIdNavigationTypeId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductFeaturesId",
                table: "ProductFeaturesDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ProductFeatureId",
                table: "OrderProductFeactures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeactures",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "OrderProductFeactureDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductFeatureId",
                table: "OrderProductFeactureDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                table: "OrderProductFeactureDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OrderIdNavigationOrderId",
                table: "OrderProductFeactureDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeactureDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductIdNavigationProductId",
                table: "OrderProductFeactureDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TypeId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TypeIdNavigationTypeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolLinks_ApplicationRoleIdNavigationUserRoleId",
                table: "RolLinks",
                column: "ApplicationRoleIdNavigationUserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TypeIdNavigationTypeId",
                table: "Reviews",
                column: "TypeIdNavigationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactures_ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeactures",
                column: "ProductFeatureIdNavigationFeaturesId");

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
                name: "IX_AspNetUsers_TypeIdNavigationTypeId",
                table: "AspNetUsers",
                column: "TypeIdNavigationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Types_TypeIdNavigationTypeId",
                table: "AspNetUsers",
                column: "TypeIdNavigationTypeId",
                principalTable: "Types",
                principalColumn: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactureDetails_Orders_OrderIdNavigationOrderId",
                table: "OrderProductFeactureDetails",
                column: "OrderIdNavigationOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactureDetails_ProductFeatures_ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeactureDetails",
                column: "ProductFeatureIdNavigationFeaturesId",
                principalTable: "ProductFeatures",
                principalColumn: "FeaturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactureDetails_Products_ProductIdNavigationProductId",
                table: "OrderProductFeactureDetails",
                column: "ProductIdNavigationProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactures_ProductFeatures_ProductFeatureIdNavigationFeaturesId",
                table: "OrderProductFeactures",
                column: "ProductFeatureIdNavigationFeaturesId",
                principalTable: "ProductFeatures",
                principalColumn: "FeaturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Types_TypeIdNavigationTypeId",
                table: "Reviews",
                column: "TypeIdNavigationTypeId",
                principalTable: "Types",
                principalColumn: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolLinks_UsersRoles_ApplicationRoleIdNavigationUserRoleId",
                table: "RolLinks",
                column: "ApplicationRoleIdNavigationUserRoleId",
                principalTable: "UsersRoles",
                principalColumn: "UserRoleId");
        }
    }
}
