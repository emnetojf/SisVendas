using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SisVendas.Models
{
    public class SisVendasContext : DbContext
    {
        public SisVendasContext (DbContextOptions<SisVendasContext> options)
            : base(options)
        {
        }

        public DbSet<SisVendas.Models.Departamento> Departamento { get; set; }
        public DbSet<SisVendas.Models.Produto> Produto { get; set; }
        public DbSet<SisVendas.Models.Vendedor> Vendedor { get; set; }
        public DbSet<SisVendas.Models.Cliente> Cliente { get; set; }
        public DbSet<SisVendas.Models.FormaPagto> FormaPagto { get; set; }
        public DbSet<SisVendas.Models.Vendas> Vendas { get; set; }
        
    }
}
