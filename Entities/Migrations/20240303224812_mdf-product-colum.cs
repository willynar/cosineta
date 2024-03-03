using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class mdfproductcolum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Reviews",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "UserScheduleId",
                table: "ProductSchedules",
                newName: "ProductScheduleId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Reviews",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ProductScheduleId",
                table: "ProductSchedules",
                newName: "UserScheduleId");
        }
    }
}
