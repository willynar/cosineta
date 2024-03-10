using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class mdforders2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Price",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Price",
                table: "OrderProductFeactureDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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
    }
}
