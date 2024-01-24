using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class mdfpkdelivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryManSchedules_AspNetUsers_ApplicationUserId",
                table: "DeliveryManSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryManSchedules_DeliveryMans_DeliveryManId",
                table: "DeliveryManSchedules");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryManSchedules_ApplicationUserId",
                table: "DeliveryManSchedules");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryManSchedules_DeliveryManId",
                table: "DeliveryManSchedules");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "DeliveryManSchedules");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryManId",
                table: "DeliveryManSchedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryManIdNavigationDeliveryManId",
                table: "DeliveryManSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryManSchedules_DeliveryManIdNavigationDeliveryManId",
                table: "DeliveryManSchedules",
                column: "DeliveryManIdNavigationDeliveryManId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryManSchedules_DeliveryMans_DeliveryManIdNavigationDeliveryManId",
                table: "DeliveryManSchedules",
                column: "DeliveryManIdNavigationDeliveryManId",
                principalTable: "DeliveryMans",
                principalColumn: "DeliveryManId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryManSchedules_DeliveryMans_DeliveryManIdNavigationDeliveryManId",
                table: "DeliveryManSchedules");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryManSchedules_DeliveryManIdNavigationDeliveryManId",
                table: "DeliveryManSchedules");

            migrationBuilder.DropColumn(
                name: "DeliveryManIdNavigationDeliveryManId",
                table: "DeliveryManSchedules");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryManId",
                table: "DeliveryManSchedules",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "DeliveryManSchedules",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryManSchedules_ApplicationUserId",
                table: "DeliveryManSchedules",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryManSchedules_DeliveryManId",
                table: "DeliveryManSchedules",
                column: "DeliveryManId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryManSchedules_AspNetUsers_ApplicationUserId",
                table: "DeliveryManSchedules",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryManSchedules_DeliveryMans_DeliveryManId",
                table: "DeliveryManSchedules",
                column: "DeliveryManId",
                principalTable: "DeliveryMans",
                principalColumn: "DeliveryManId");
        }
    }
}
