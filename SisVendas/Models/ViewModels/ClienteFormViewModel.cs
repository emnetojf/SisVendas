using System.Collections.Generic;
using SisVendas.Models.Enums;

namespace SisVendas.Models.ViewModels
{
    public class ClienteFormViewModel
    {
        public Cliente Cliente { get; set; }
        public ICollection<Cliente> Clientes { get; set; }

        public Sexo Sexo { get; set; }
        public UF UF { get; set; }
    }
}
