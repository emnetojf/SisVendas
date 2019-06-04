using Microsoft.EntityFrameworkCore;

namespace SisVendas.Models
{
    public class SisVendasContext : DbContext
    {
        public SisVendasContext (DbContextOptions<SisVendasContext> options)
            : base(options)
        {
        }

        public DbSet<SisVendas.Models.Departamento> Departamentos { get; set; }
        public DbSet<SisVendas.Models.Produto> Produtos { get; set; }
        public DbSet<SisVendas.Models.Vendedor> Vendedor { get; set; }
        public DbSet<SisVendas.Models.Cliente> Clientes { get; set; }
        public DbSet<SisVendas.Models.FormaPagto> FormaPagtos { get; set; }
        public DbSet<SisVendas.Models.Vendas> Vendas { get; set; }
        public DbSet<SisVendas.Models.ItemVendas> ItemVendas { get; set; }

    }
}
