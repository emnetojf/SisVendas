using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisVendas.Models.ViewModels
{
    public class FormaPagtoFormViewModel
    {
        public FormaPagto FormaPagto { get; set; }
        public ICollection<FormaPagto> formaPagtos{ get; set; }
    }
}
