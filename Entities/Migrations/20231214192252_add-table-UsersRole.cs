using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class addtableUsersRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_ApplicationUserIdNavigationId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_RolLinks_AspNetRoles_ApplicationRoleIdNavigationId",
                table: "RolLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_RolLinks_Links_LinkIdNavigationLinkId",
                table: "RolLinks");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_ApplicationUserIdNavigationId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "ApplicationUserIdNavigationId",
                table: "AspNetUserRoles");

            migrationBuilder.AlterColumn<int>(
                name: "LinkIdNavigationLinkId",
                table: "RolLinks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationRoleIdNavigationId",
                table: "RolLinks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationRoleIdNavigationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UsersRoles_AspNetRoles_ApplicationRoleIdNavigationId",
                        column: x => x.ApplicationRoleIdNavigationId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersRoles_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_ApplicationRoleIdNavigationId",
                table: "UsersRoles",
                column: "ApplicationRoleIdNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_ApplicationUserId",
                table: "UsersRoles",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolLinks_AspNetRoles_ApplicationRoleIdNavigationId",
                table: "RolLinks",
                column: "ApplicationRoleIdNavigationId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolLinks_Links_LinkIdNavigationLinkId",
                table: "RolLinks",
                column: "LinkIdNavigationLinkId",
                principalTable: "Links",
                principalColumn: "LinkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolLinks_AspNetRoles_ApplicationRoleIdNavigationId",
                table: "RolLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_RolLinks_Links_LinkIdNavigationLinkId",
                table: "RolLinks");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.AlterColumn<int>(
                name: "LinkIdNavigationLinkId",
                table: "RolLinks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationRoleIdNavigationId",
                table: "RolLinks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserIdNavigationId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_ApplicationUserIdNavigationId",
                table: "AspNetUserRoles",
                column: "ApplicationUserIdNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_ApplicationUserIdNavigationId",
                table: "AspNetUserRoles",
                column: "ApplicationUserIdNavigationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolLinks_AspNetRoles_ApplicationRoleIdNavigationId",
                table: "RolLinks",
                column: "ApplicationRoleIdNavigationId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolLinks_Links_LinkIdNavigationLinkId",
                table: "RolLinks",
                column: "LinkIdNavigationLinkId",
                principalTable: "Links",
                principalColumn: "LinkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
