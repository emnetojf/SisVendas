using System.Collections.Generic;

namespace SisVendas.Models.ViewModels
{
    public class FormaPagtoFormViewModel
    {
        public FormaPagto FormaPagto { get; set; }
        public ICollection<FormaPagto> formaPagtos{ get; set; }
    }
}
