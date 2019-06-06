using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisVendas.Models.ViewModels
{
    public class ClienteFormViewModel
    {
        public Cliente cliente { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
