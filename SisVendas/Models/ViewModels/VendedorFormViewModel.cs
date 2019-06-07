using System.Collections.Generic;

namespace SisVendas.Models.ViewModels
{
    public class VendedorFormViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; }
    }
}
