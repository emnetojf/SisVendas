using System.Collections.Generic;

namespace SisVendas.Models.ViewModels
{
    public class VendasFormViewModel
    {
        public Vendas Venda { get; set; }
        public ItemVendas Itemvenda { get; set; }

        public ICollection<Vendas> Vendas { get; set; }
        public ICollection<ItemVendas> ItemVendas { get; set; }
    }
}
