using Microsoft.EntityFrameworkCore.Migrations;

namespace SisVendas.Migrations
{
    public partial class VendedorSenha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemVendas_VendasId",
                table: "ItemVendas");

            migrationBuilder.DropColumn(
                name: "TotalVend",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "intQuant",
                table: "ItemVendas");

            migrationBuilder.RenameColumn(
                name: "strNomeCli",
                table: "Clientes",
                newName: "StrNomeCli");

            migrationBuilder.AddColumn<string>(
                name: "strSenha",
                table: "Vendedor",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "douQuant",
                table: "ItemVendas",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendas_VendasId",
                table: "ItemVendas",
                column: "VendasId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemVendas_VendasId",
                table: "ItemVendas");

            migrationBuilder.DropColumn(
                name: "strSenha",
                table: "Vendedor");

            migrationBuilder.DropColumn(
                name: "douQuant",
                table: "ItemVendas");

            migrationBuilder.RenameColumn(
                name: "StrNomeCli",
                table: "Clientes",
                newName: "strNomeCli");

            migrationBuilder.AddColumn<double>(
                name: "TotalVend",
                table: "Vendas",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "intQuant",
                table: "ItemVendas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendas_VendasId",
                table: "ItemVendas",
                column: "VendasId");
        }
    }
}
