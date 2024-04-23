using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class updordermdfadr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductFeactures_OrderProducts_OrderProductId",
                table: "OrderProductFeactures");

            migrationBuilder.DropTable(
                name: "OrderProductFeactureDetails");

            migrationBuilder.DropTable(
                name: "OrderProductFeactureOnly");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductFeactures_OrderProductId",
                table: "OrderProductFeactures");

            migrationBuilder.DropColumn(
                name: "AdditionalValue",
                table: "OrderProductFeactures");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "Orders",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Features",
                table: "OrderProductFeactures",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "OrderProductFeactureId",
                table: "OrderProductFeactures",
                newName: "OrderProductCategoryFeactureId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserIdSeller",
                table: "OrderProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Categories",
                table: "OrderProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductFeactureCategory",
                table: "OrderProductFeactures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Required",
                table: "OrderProductFeactures",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserIdSeller",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "Categories",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "ProductFeactureCategory",
                table: "OrderProductFeactures");

            migrationBuilder.DropColumn(
                name: "Required",
                table: "OrderProductFeactures");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Orders",
                newName: "Direccion");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "OrderProductFeactures",
                newName: "Features");

            migrationBuilder.RenameColumn(
                name: "OrderProductCategoryFeactureId",
                table: "OrderProductFeactures",
                newName: "OrderProductFeactureId");

            migrationBuilder.AddColumn<decimal>(
                name: "AdditionalValue",
                table: "OrderProductFeactures",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderProductFeactureOnly",
                columns: table => new
                {
                    OrderProductFeactureOnlyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ApplicationUserIdFeacture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdditional = table.Column<bool>(type: "bit", nullable: false),
                    MultipleSelection = table.Column<bool>(type: "bit", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProductFeactureOnly", x => x.OrderProductFeactureOnlyId);
                });

            migrationBuilder.CreateTable(
                name: "OrderProductFeactureDetails",
                columns: table => new
                {
                    OrderProductFeactureDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrderProductFeactureOnlyId = table.Column<int>(type: "int", nullable: false),
                    OrderProductId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserIdSeller = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StarTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProductFeactureDetails", x => x.OrderProductFeactureDetailId);
                    table.ForeignKey(
                        name: "FK_OrderProductFeactureDetails_OrderProductFeactureOnly_OrderProductFeactureOnlyId",
                        column: x => x.OrderProductFeactureOnlyId,
                        principalTable: "OrderProductFeactureOnly",
                        principalColumn: "OrderProductFeactureOnlyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProductFeactureDetails_OrderProducts_OrderProductId",
                        column: x => x.OrderProductId,
                        principalTable: "OrderProducts",
                        principalColumn: "OrderProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProductFeactureDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactures_OrderProductId",
                table: "OrderProductFeactures",
                column: "OrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactureDetails_OrderId",
                table: "OrderProductFeactureDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactureDetails_OrderProductFeactureOnlyId",
                table: "OrderProductFeactureDetails",
                column: "OrderProductFeactureOnlyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductFeactureDetails_OrderProductId",
                table: "OrderProductFeactureDetails",
                column: "OrderProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductFeactures_OrderProducts_OrderProductId",
                table: "OrderProductFeactures",
                column: "OrderProductId",
                principalTable: "OrderProducts",
                principalColumn: "OrderProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
