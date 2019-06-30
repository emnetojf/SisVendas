using SisVendas.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SisVendas.Models
{
    public class Vendas
    {
        [Key]
        public int IdVenda { get; set; }

        public virtual Vendedor Vendedor { get; set; }
        public int VendedorId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        public virtual FormaPagto Pagto { get; set; }
        public int FormaPagtoId { get; set; }       

        [Required(ErrorMessage = "{0} requerido!")]
        [Display(Name = "Data Venda")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]       
        public DateTime dtVenda { get; set; }

        public StatusVendas Status { get; set; }

        /*
        public string ListaProdutos { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:F2}")] // Formato 0.00
        public double TotalVend { get; set; }
        */

        public Vendas()
        {}

        public Vendas(int idVenda, Vendedor vendedor, Cliente cliente, FormaPagto pagto, DateTime dtVenda, StatusVendas status)
        {
            IdVenda = idVenda;
            Vendedor = vendedor;
            Cliente = cliente;
            Pagto = pagto;            
            this.dtVenda = dtVenda;
            Status = status;
        }       
    }
}
