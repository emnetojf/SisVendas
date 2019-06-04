using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SisVendas.Models
{
    public class Vendedor
    {
        [Key]
        public int IdVend { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve conter no mínimo {2} e no máximo {}!")]
        public string StrNomeVend { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Entre com email válido")]
        [DataType(DataType.EmailAddress)]
        public string strEmail { get; set; }
        
        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 1200.0, ErrorMessage = "{0} deve ser entre {1} e {2}")]
        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double douSalBase { get; set; }

      


        public Vendedor()
        { }

        public Vendedor(int idVend, string strNomeVend, string strEmail, double douSalBase)
        {
            IdVend = idVend;
            StrNomeVend = strNomeVend;
            this.strEmail = strEmail;
            this.douSalBase = douSalBase;
        }
    }
}
