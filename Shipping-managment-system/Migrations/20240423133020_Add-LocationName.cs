using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping_managment_system.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "shipments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "shipments");
        }
    }
}
