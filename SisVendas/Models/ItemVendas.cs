using System.ComponentModel.DataAnnotations;

namespace SisVendas.Models
{
    public class ItemVendas
    {
        [Key]
        public int ItemID { get; set; }

        public virtual Vendas Vendas { get; set; }
        public int VendasId { get; set; }

        public virtual Produto Produto { get; set; }
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "{0} requerido!")]
        [DisplayFormat(DataFormatString = "{0:F2}")] // Formato 0.00
        public double douQuant { get; set; }


        [Required(ErrorMessage = "{0} requerido!")]
        [Display(Name = "Preço do produto!")]
        [DisplayFormat(DataFormatString = "{0:F2}")] // Formato 0.00
        public double douValor { get; set; }  

        public ItemVendas()
        { }

        public ItemVendas(int itemID, int vendasId, int produtoId, double douQuant, double douValor)
        {
            ItemID = itemID;
            VendasId = vendasId;            
            ProdutoId = produtoId;
            this.douQuant = douQuant;
            this.douValor = douValor;
        }

        public ItemVendas(int produtoId, double douQuant, double douValor)
        {
            ProdutoId = produtoId;
            this.douQuant = douQuant;
            this.douValor = douValor;
        }


    }
}
