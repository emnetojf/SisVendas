using System.Collections.Generic;
using SisVendas.Models.Enums;

namespace SisVendas.Models.ViewModels
{
    public class VendasFormViewModel
    {
        public Vendas Venda { get; set; }
        public StatusVendas Status { get; set; }

        public ItemVendas Itemvenda { get; set; }

        public ICollection<Vendedor> Vendedores { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<FormaPagto> FormaPagtos { get; set; }

        public ICollection<Vendas> Vendas { get; set; }
        
        public ICollection<Produto> Produtos { get; set; }
    }
}
