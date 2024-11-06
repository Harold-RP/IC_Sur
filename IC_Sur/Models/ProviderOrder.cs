using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC_Sur.Models
{
    public class ProviderOrder
    {
        [Key]
        public int ProviderOrderId { get; set; }

        [ForeignKey("Product")]
        [Display(Name = "Producto")]
        public int ProductId { get; set; }
        
        [Display(Name = "Producto")]
        public Product? Product { get; set; }

        [Display(Name = "Cantidad")]
        public int Amount { get; set; }
        
        [Display(Name = "Fecha/Hora Pedido")]
        public DateTime DateTimeOrder { get; set; }

        [Display(Name = "Costo Total")]
        public double TotalCost { get; set; }
    }
}
