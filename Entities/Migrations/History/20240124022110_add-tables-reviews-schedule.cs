using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class addtablesreviewsschedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ProductsReviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ChefReviews",
                columns: table => new
                {
                    IdChefReview = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    ChefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChefReviews", x => x.IdChefReview);
                    table.ForeignKey(
                        name: "FK_ChefReviews_Chefs_ChefId",
                        column: x => x.ChefId,
                        principalTable: "Chefs",
                        principalColumn: "ChefId");
                });

            migrationBuilder.CreateTable(
                name: "DeliveryMans",
                columns: table => new
                {
                    DeliveryManId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMans", x => x.DeliveryManId);
                    table.ForeignKey(
                        name: "FK_DeliveryMans_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryManReviews",
                columns: table => new
                {
                    IdDeliveryManReview = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    DeliveryManId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryManReviews", x => x.IdDeliveryManReview);
                    table.ForeignKey(
                        name: "FK_DeliveryManReviews_DeliveryMans_DeliveryManId",
                        column: x => x.DeliveryManId,
                        principalTable: "DeliveryMans",
                        principalColumn: "DeliveryManId");
                });

            migrationBuilder.CreateTable(
                name: "DeliveryManSchedules",
                columns: table => new
                {
                    DeliveryManScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StarTime = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeliveryManId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryManSchedules", x => x.DeliveryManScheduleId);
                    table.ForeignKey(
                        name: "FK_DeliveryManSchedules_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryManSchedules_DeliveryMans_DeliveryManId",
                        column: x => x.DeliveryManId,
                        principalTable: "DeliveryMans",
                        principalColumn: "DeliveryManId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChefReviews_ChefId",
                table: "ChefReviews",
                column: "ChefId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryManReviews_DeliveryManId",
                table: "DeliveryManReviews",
                column: "DeliveryManId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryMans_ApplicationUserId",
                table: "DeliveryMans",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryManSchedules_ApplicationUserId",
                table: "DeliveryManSchedules",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryManSchedules_DeliveryManId",
                table: "DeliveryManSchedules",
                column: "DeliveryManId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChefReviews");

            migrationBuilder.DropTable(
                name: "DeliveryManReviews");

            migrationBuilder.DropTable(
                name: "DeliveryManSchedules");

            migrationBuilder.DropTable(
                name: "DeliveryMans");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ProductsReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
