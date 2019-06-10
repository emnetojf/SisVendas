using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SisVendas.Models.Enums;

namespace SisVendas.Models
{
    public class Vendas
    {
        [Key]
        public int IdVenda { get; set; }

        public Vendedor Vendedor { get; set; }
        public int VendedorId { get; set; }

        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        public FormaPagto Pagto { get; set; }
        public int FormaPagtoId { get; set; }

        public ICollection<ItemVendas> ItemVendas { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [Display(Name = "Data Venda")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]       
        public DateTime dtVenda { get; set; }

        public StatusVendas Status { get; set; }

        

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
