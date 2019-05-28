using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisVendas.Models
{
    public class Cliente
    {
        public int IdCli { get; set; }
        public string strNomeCli { get; set; }
        public DateTime DtNasc { get; set; }
        public string strSexo { get; set; }
        public string strUF { get; set; }

        public Cliente()
        { }

        public Cliente(int idCli, string strNomeCli, DateTime dtNasc, string strSexo, string strUF)
        {
            IdCli = idCli;
            this.strNomeCli = strNomeCli;
            DtNasc = dtNasc;
            this.strSexo = strSexo;
            this.strUF = strUF;
        }
    }
}
