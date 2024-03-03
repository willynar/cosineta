using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class mdforderaddtbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactures_OrderProductFeactureDetails_OrderProductFeactureDetailId",
                table: "OrderProductFeactures");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductFeactures_OrderProductFeactureDetailId",
                table: "OrderProductFeactures");

            migrationBuilder.DropColumn(
                name: "OrderProductFeactureDetailId",
                table: "OrderProductFeactures");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderProductFeactures");

            migrationBuilder.DropColumn(
                name: "ProductFeatureId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.RenameColumn(
                name: "ProductFeatureId",
                table: "OrderProductFeactures",
                newName: "OrderProductId");

            migrationBuilder.RenameColumn(
                name: "OrderProductFeactureIs",
                table: "OrderProductFeactures",
                newName: "OrderProductFeactureId");

            migrationBuilder.AddColumn<decimal>(
                name: "AdditionalValue",
                table: "OrderProductFeactures",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserIdFeacture",
                table: "OrderProductFeactures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdditional",
                table: "OrderProductFeactures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MultipleSelection",
                table: "OrderProductFeactures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OrderProductFeactureOnlyId",
                table: "OrderProductFeactureDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderProductId",
                table: "OrderProductFeactureDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrderProductFeactureOnly",
                columns: table => new
                {
                    OrderProductFeactureOnlyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MultipleSelection = table.Column<bool>(type: "bit", nullable: false),
                    IsAdditional = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserIdFeacture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProductFeactureOnly", x => x.OrderProductFeactureOnlyId);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    OrderProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Taxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Review = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Serving = table.Column<int>(type: "int", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserIdFeacture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.OrderProductId);
                });

            migrationBuilder.CreateTable(
                name: "OrderProductTaxes",
                columns: table => new
                {
                    OrderProductTaxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Taxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StarTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProductTaxes", x => x.OrderProductTaxId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactures_OrderProductId",
                table: "OrderProductFeactures",
                column: "OrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactureDetails_OrderProductFeactureOnlyId",
                table: "OrderProductFeactureDetails",
                column: "OrderProductFeactureOnlyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactureDetails_OrderProductId",
                table: "OrderProductFeactureDetails",
                column: "OrderProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactureDetails_OrderProductFeactureOnly_OrderProductFeactureOnlyId",
                table: "OrderProductFeactureDetails",
                column: "OrderProductFeactureOnlyId",
                principalTable: "OrderProductFeactureOnly",
                principalColumn: "OrderProductFeactureOnlyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactureDetails_OrderProducts_OrderProductId",
                table: "OrderProductFeactureDetails",
                column: "OrderProductId",
                principalTable: "OrderProducts",
                principalColumn: "OrderProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactures_OrderProducts_OrderProductId",
                table: "OrderProductFeactures",
                column: "OrderProductId",
                principalTable: "OrderProducts",
                principalColumn: "OrderProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactureDetails_OrderProductFeactureOnly_OrderProductFeactureOnlyId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactureDetails_OrderProducts_OrderProductId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactures_OrderProducts_OrderProductId",
                table: "OrderProductFeactures");

            migrationBuilder.DropTable(
                name: "OrderProductFeactureOnly");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "OrderProductTaxes");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductFeactures_OrderProductId",
                table: "OrderProductFeactures");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductFeactureDetails_OrderProductFeactureOnlyId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductFeactureDetails_OrderProductId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropColumn(
                name: "AdditionalValue",
                table: "OrderProductFeactures");

            migrationBuilder.DropColumn(
                name: "ApplicationUserIdFeacture",
                table: "OrderProductFeactures");

            migrationBuilder.DropColumn(
                name: "IsAdditional",
                table: "OrderProductFeactures");

            migrationBuilder.DropColumn(
                name: "MultipleSelection",
                table: "OrderProductFeactures");

            migrationBuilder.DropColumn(
                name: "OrderProductFeactureOnlyId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropColumn(
                name: "OrderProductId",
                table: "OrderProductFeactureDetails");

            migrationBuilder.RenameColumn(
                name: "OrderProductId",
                table: "OrderProductFeactures",
                newName: "ProductFeatureId");

            migrationBuilder.RenameColumn(
                name: "OrderProductFeactureId",
                table: "OrderProductFeactures",
                newName: "OrderProductFeactureIs");

            migrationBuilder.AddColumn<int>(
                name: "OrderProductFeactureDetailId",
                table: "OrderProductFeactures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "OrderProductFeactures",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductFeatureId",
                table: "OrderProductFeactureDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderProductFeactureDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactures_OrderProductFeactureDetailId",
                table: "OrderProductFeactures",
                column: "OrderProductFeactureDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactures_OrderProductFeactureDetails_OrderProductFeactureDetailId",
                table: "OrderProductFeactures",
                column: "OrderProductFeactureDetailId",
                principalTable: "OrderProductFeactureDetails",
                principalColumn: "OrderProductFeactureDetailId");
        }
    }
}
