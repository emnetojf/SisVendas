using System.ComponentModel.DataAnnotations;

namespace SisVendas.Models
{
    public class Produto
    {
        [Key]
        public int IdProd { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [Display(Name = "ID")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve conter no mínimo {2} e no máximo {1}!")]
        public string strNomeProd { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [Display(Name = "Preço do produto")]
        [DisplayFormat(DataFormatString = "{0:F2}")] // Formato 0.00
        public double douPreco { get; set; }

        public Produto()
        { }

        public Produto(int idProd, string strNomeProd, double douPreco)
        {
            IdProd = idProd;
            this.strNomeProd = strNomeProd;
            this.douPreco = douPreco;
        }
    }
}
