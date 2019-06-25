using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SisVendas.Models
{
    public class Produto
    {
        [Key]
        public int IdProd { get; set; }

        [Required(ErrorMessage = "Informe nome produto!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve conter no mínimo {2} e no máximo {1}!")]
        public string strNomeProd { get; set; }

        [Required(ErrorMessage = "Informe preço produto!")]
        [DisplayFormat(DataFormatString = "{0:F2}")] // Formato 0.00
        public double douPreco { get; set; }

        [Required(ErrorMessage = "Informe quantidade produto!")]
        [DisplayFormat(DataFormatString = "{0:F2}")] // Formato 0.00
        public double douQuant { get; set; }

        [Required(ErrorMessage = "Informe unidade produto!")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "{0} deve conter no mínimo {2} e no máximo {1}!")]
        public string strUnid { get; set; }

        [Required(ErrorMessage = "Informe foto produto!")]
        public string strFoto { get; set; }

        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<Vendas> Vendas { get; set; } = new List<Vendas>();



        public Produto()
        { }

        public Produto(int idProd, string strNomeProd, double douPreco, double douQuant, string strUnid, string strFoto, Departamento departamento)
        {
            IdProd = idProd;
            this.strNomeProd = strNomeProd;
            this.douPreco = douPreco;
            this.douQuant = douQuant;
            this.strUnid = strUnid;
            this.strFoto = strFoto;
            this.Departamento = departamento;
        }
    }
}
