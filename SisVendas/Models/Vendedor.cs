using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisVendas.Models
{
    public class Vendedor
    {
        public int IdVend{ get; set; }
        public string strNomeVend { get; set; }
        public string strEmail { get; set; }
        public double douSalBase { get; set; }

        public Vendedor()
        { }

        public Vendedor(int idVend, string strNomeVend, string strEmail, double douSalBase)
        {
            IdVend = idVend;
            this.strNomeVend = strNomeVend;
            this.strEmail = strEmail;
            this.douSalBase = douSalBase;
        }
    }
}
