﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SisVendas.Models
{
    public class Vendedor
    {
        [Key]
        public int IdVend { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [Display(Name = "Vendedor")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve conter no mínimo {2} e no máximo {1}!")]
        public string StrNomeVend { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Entre com email válido")]
        [DataType(DataType.EmailAddress)]
        public string strEmail { get; set; }
        
        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 1200.0, ErrorMessage = "{0} deve ser entre {1} e {2}")]
        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double douSalBase { get; set; }

        [Required(ErrorMessage = "Informe {0} Usuário")]
        [Display(Name = "Senha")]
        public string strSenha { get; set; }

        public ICollection<Vendas> Vendas { get; set; } = new List<Vendas>();

        public Vendedor()
        { }

        public Vendedor(int idVend, string strNomeVend, string strEmail, double douSalBase, string strSenha)
        {
            IdVend = idVend;
            StrNomeVend = strNomeVend;
            this.strEmail = strEmail;
            this.douSalBase = douSalBase;
            this.strSenha = strSenha;
        }
    }
}
