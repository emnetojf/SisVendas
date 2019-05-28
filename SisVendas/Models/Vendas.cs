using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SisVendas.Models.Enums;

namespace SisVendas.Models
{
    public class Vendas
    {
        [Key]
        public int IdVenda { get; set; }
        public DateTime dtVenda { get; set; }
        public double douVlVenda { get; set; }
        //public StatusVendas StatusVenda { get; set; }

        public Vendas()
        {}

        public Vendas(int idVenda, DateTime dtVenda, double douVlVenda)
        {
            IdVenda = idVenda;
            this.dtVenda = dtVenda;
            this.douVlVenda = douVlVenda;
            //StatusVenda = statusVenda;
        }
    }
}
