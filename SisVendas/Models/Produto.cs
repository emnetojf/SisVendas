using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisVendas.Models
{
    public class Produto
    {
        [Key]
        public int IdProd { get; set; }
        public string strNomeProd { get; set; }
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
