using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByTech_API.Migrations
{
    /// <inheritdoc />
    public partial class pedidostatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<int>(
                name: "id_status_pedido",
                table: "pedido",
                type: "int(11)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_pedido_id_status_pedido",
                table: "pedido",
                column: "id_status_pedido");

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_status_pedido_id_status_pedido",
                table: "pedido",
                column: "id_status_pedido",
                principalTable: "status_pedido",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedido_status_pedido_id_status_pedido",
                table: "pedido");

            migrationBuilder.DropIndex(
                name: "IX_pedido_id_status_pedido",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "id_status_pedido",
                table: "pedido");

            
        }
    }
}
