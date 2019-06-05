using System.ComponentModel.DataAnnotations;


namespace SisVendas.Models
{
    public class FormaPagto
    {
        [Key]
        public int IdPagto { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} deve conter no mínimo {2} e no máximo {1}!")]
        public string strPagto { get; set; }

        public FormaPagto()
        { }

        public FormaPagto(int idPagto, string strPagto)
        {
            IdPagto = idPagto;
            this.strPagto = strPagto;
        }
    }
}
