using System.Collections.Generic;

namespace SisVendas.Models.ViewModels
{
    public class ProdutoFormViewModel
    {
        public Produto Produto { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
