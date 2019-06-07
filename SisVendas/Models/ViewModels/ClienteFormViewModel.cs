using SisVendas.Models.Enums;
using System.Collections.Generic;

namespace SisVendas.Models.ViewModels
{
    public class ClienteFormViewModel
    {
        public Cliente Cliente { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Sexo> Sexo { get; set; }
        public ICollection<UF> UFs { get; set; }
    }
}
