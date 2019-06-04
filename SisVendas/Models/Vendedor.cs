using System.ComponentModel.DataAnnotations;


namespace SisVendas.Models
{
    public class Vendedor
    {
        [Key]
        public int IdVend { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Tamanho {0} deve ser entre {2} e {1}!")]
        public string strNomeVend { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [DataType(DataType.EmailAddress)]
        public string strEmail { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [Range(100,1200, ErrorMessage = "{0} deve ser entre {1} e {2}!")]
        [Display(Name = "Salário Base!")]
        [DisplayFormat(DataFormatString = "{0:F2}")] // Formato 0.00
        public double douSalBase { get; set; }

        public Departamento Depto { get; set; }
        public int DeptoId { get; set; }
        


        public Vendedor()
        { }

        public Vendedor(int idVend, string strNomeVend, string strEmail, double douSalBase, Departamento depto)
        {
            this.IdVend = idVend;
            this.strNomeVend = strNomeVend;
            this.strEmail = strEmail;
            this.douSalBase = douSalBase;
            this.Depto = depto;
        }

       
    }
}
