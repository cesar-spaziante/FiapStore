using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiapStore.Migrations
{
    /// <inheritdoc />
    public partial class Adicionando_Preco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrecoTotal",
                table: "pedido",
                type: "DECIMAL(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoTotal",
                table: "pedido");
        }
    }
}
