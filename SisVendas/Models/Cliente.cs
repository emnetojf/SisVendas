﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SisVendas.Models.Enums;

namespace SisVendas.Models
{
    public class Cliente
    {
        [Key]
        public int IdCli { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve conter no mínimo {2} e no máximo {}!")]
        public string strNomeCli { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [Display(Name = "Data Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DtNasc { get; set; }

        public Sexo Sexo { get; set; }
        public UF UF { get; set; }


        public List<Vendas> ListCompras { get; set; } = new List<Vendas>();


        public Cliente()
        { }

        public Cliente(int idCli, string strNomeCli, DateTime dtNasc, Sexo sexo, UF uf)
        {
            IdCli = idCli;
            this.strNomeCli = strNomeCli;
            DtNasc = dtNasc;
            Sexo = sexo;
            UF = uf;
        }

        public void AdicVendas (Vendas vendas)
        {
            ListCompras.Add(vendas);
        }

        public void RemovVendas(Vendas vendas)
        {
            ListCompras.Remove(vendas);
        }

        public double TotalCompras(DateTime DtInicial, DateTime DtFinal)
        {
            return ListCompras.Where(Vendas => Vendas.dtVenda >= DtInicial && Vendas.dtVenda <= DtInicial).Sum(Vendas => Vendas.douVlVenda);
        }

    }
}
