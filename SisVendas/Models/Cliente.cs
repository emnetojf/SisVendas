using System;
using System.ComponentModel.DataAnnotations;
using SisVendas.Models.Enums;

namespace SisVendas.Models
{
    public class Cliente
    {
        [Key]
        public int IdCli { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve conter no mínimo {2} e no máximo {1}!")]
        public string strNomeCli { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [Display(Name = "Data Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DtNasc { get; set; }

        public Sexo Sexo { get; set; }
        public int SexoId { get; set; }

        public UF Uf { get; set; }
        public int UFId { get; set; }
        


        public Cliente()
        { }

        public Cliente(int idCli, string strNomeCli, DateTime dtNasc, Sexo sexo, UF uf)
        {
            IdCli = idCli;
            this.strNomeCli = strNomeCli;
            DtNasc = dtNasc;
            Sexo = sexo;
            Uf = uf;
        }
    }
}
