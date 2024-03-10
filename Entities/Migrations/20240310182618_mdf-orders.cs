using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class mdforders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationUserIdFeacture",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserIdFeacture",
                table: "OrderProductFeactures");

            migrationBuilder.AddColumn<string>(
                name: "Bin",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Kilometers",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserIdSeller",
                table: "OrderProductFeactureDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderProductFeactureDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "OrderProductFeactureDetails",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "OrderProductFeactureDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderProductFeactureDetails",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Review",
                table: "OrderProductFeactureDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Serving",
                table: "OrderProductFeactureDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "OrderProductFeactureDetails",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bin",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Kilometers",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApplicationUserIdSeller",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropColumn(
                name: "Review",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropColumn(
                name: "Serving",
                table: "OrderProductFeactureDetails");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "OrderProductFeactureDetails");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserIdFeacture",
                table: "OrderProducts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserIdFeacture",
                table: "OrderProductFeactures",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
