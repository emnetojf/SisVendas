using System.ComponentModel.DataAnnotations;

namespace SisVendas.Models
{
    public class ItemVendas
    {
        [Key]
        public int ItemVendasID { get; set; }

        public Vendas Vendas { get; set; }
        public int VendasId { get; set; }

        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [Display(Name = "Quantidade!")]
        public int intQuant { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [Display(Name = "Preço do produto!")]
        [DisplayFormat(DataFormatString = "{0:F2}")] // Formato 0.00
        public double douValor { get; set; }

       

        public ItemVendas()
        { }

        public ItemVendas(int itemVendasID, Vendas vendas, Produto produto, int intQuant, double douValor)
        {
            ItemVendasID = itemVendasID;
            Vendas = vendas;
            Produto= produto;
            this.intQuant = intQuant;
            this.douValor = douValor;
        }

        
    }
}
