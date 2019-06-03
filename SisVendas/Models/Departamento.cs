using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SisVendas.Models
{
    public class Departamento
    {
        [Key]
        public int IdDepto { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} deve conter no mínimo {2} e no máximo {1}!")]
        public string strDepto { get; set; }
        
        public ICollection<Vendedor> ListaVendedores { get; set; } = new List<Vendedor>();


        public Departamento()
        { }

        public Departamento(int idDepto, string strDepto)
        {
            IdDepto = idDepto;
            this.strDepto = strDepto;
        }

        public void AdicVendedor(Vendedor vendedor)
        {
            ListaVendedores.Add(vendedor);
        }

        public void RemovVendedor(Vendedor vendedor)
        {
            ListaVendedores.Remove(vendedor);
        }


        public double TotalVendas(DateTime DtInicial, DateTime DtFinal)
        {
            return ListaVendedores.Sum(vendedores => vendedores.TotalVendas(DtInicial, DtFinal));
        }
    }
}
