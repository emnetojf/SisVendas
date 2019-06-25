using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SisVendas.Models
{
    public class Departamento
    {
        [Key]
        public int IdDepto { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} deve conter no mínimo {2} e no máximo {1}!")]
        public string strDepto { get; set; }

        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();


        public Departamento()
        { }

        public Departamento(int idDepto, string strDepto)
        {
            IdDepto = idDepto;
            this.strDepto = strDepto;
        }       
    }
}
