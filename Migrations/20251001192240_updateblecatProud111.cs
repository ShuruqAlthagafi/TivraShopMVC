using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TivraShopMVC.Migrations
{
    /// <inheritdoc />
    public partial class updateblecatProud111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Clients",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Clients",
                newName: "PasswordHash");
        }
    }
}
