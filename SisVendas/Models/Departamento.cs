using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisVendas.Models
{
    public class Departamento
    {
        public int IdDepto { get; set; }
        public string strDepto { get; set; }

        public Departamento()
        { }

        public Departamento(int idDepto, string strDepto)
        {
            IdDepto = idDepto;
            this.strDepto = strDepto;
        }
    }
}
