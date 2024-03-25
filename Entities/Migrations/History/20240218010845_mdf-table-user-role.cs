using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class mdftableuserrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolLinks_AspNetRoles_ApplicationRoleIdNavigationId",
                table: "RolLinks");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "RolLinks",
                newName: "UserRoleId");

            migrationBuilder.RenameColumn(
                name: "ApplicationRoleIdNavigationId",
                table: "RolLinks",
                newName: "ApplicationRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RolLinks_ApplicationRoleIdNavigationId",
                table: "RolLinks",
                newName: "IX_RolLinks_ApplicationRoleId");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "UsersRoles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationRoleIdNavigationUserRoleId",
                table: "RolLinks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolLinks_ApplicationRoleIdNavigationUserRoleId",
                table: "RolLinks",
                column: "ApplicationRoleIdNavigationUserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolLinks_AspNetRoles_ApplicationRoleId",
                table: "RolLinks",
                column: "ApplicationRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolLinks_UsersRoles_ApplicationRoleIdNavigationUserRoleId",
                table: "RolLinks",
                column: "ApplicationRoleIdNavigationUserRoleId",
                principalTable: "UsersRoles",
                principalColumn: "UserRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolLinks_AspNetRoles_ApplicationRoleId",
                table: "RolLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_RolLinks_UsersRoles_ApplicationRoleIdNavigationUserRoleId",
                table: "RolLinks");

            migrationBuilder.DropIndex(
                name: "IX_RolLinks_ApplicationRoleIdNavigationUserRoleId",
                table: "RolLinks");

            migrationBuilder.DropColumn(
                name: "ApplicationRoleIdNavigationUserRoleId",
                table: "RolLinks");

            migrationBuilder.RenameColumn(
                name: "UserRoleId",
                table: "RolLinks",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "ApplicationRoleId",
                table: "RolLinks",
                newName: "ApplicationRoleIdNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_RolLinks_ApplicationRoleId",
                table: "RolLinks",
                newName: "IX_RolLinks_ApplicationRoleIdNavigationId");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "UsersRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RolLinks_AspNetRoles_ApplicationRoleIdNavigationId",
                table: "RolLinks",
                column: "ApplicationRoleIdNavigationId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }
    }
}
