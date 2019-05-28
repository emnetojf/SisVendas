using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisVendas.Models
{
    public class FormaPagto
    {
        public int IdPagto { get; set; }
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
