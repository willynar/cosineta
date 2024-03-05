﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class mdfproductcolumTYPE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Types_TypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "TypeId",
            //    table: "Products",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_TypeId",
            //    table: "Products",
            //    column: "TypeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Products_Types_TypeId",
            //    table: "Products",
            //    column: "TypeId",
            //    principalTable: "Types",
            //    principalColumn: "TypeId");
        }
    }
}
