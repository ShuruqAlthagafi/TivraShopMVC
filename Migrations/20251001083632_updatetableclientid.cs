using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TivraShopMVC.Migrations
{
    /// <inheritdoc />
    public partial class updatetableclientid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Clients",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clients",
                newName: "ClientId");
        }
    }
}
