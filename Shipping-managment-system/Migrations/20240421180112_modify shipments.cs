using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping_managment_system.Migrations
{
    /// <inheritdoc />
    public partial class modifyshipments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shipments_addresses_AddressId",
                table: "shipments");

            migrationBuilder.DropIndex(
                name: "IX_shipments_AddressId",
                table: "shipments");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "shipments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "shipments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_shipments_AddressId",
                table: "shipments",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_shipments_addresses_AddressId",
                table: "shipments",
                column: "AddressId",
                principalTable: "addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
