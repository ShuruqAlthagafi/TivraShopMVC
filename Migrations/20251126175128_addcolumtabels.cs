using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TivraShopMVC.Migrations
{
    /// <inheritdoc />
    public partial class addcolumtabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Uid",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Categories");
        }
    }
}
