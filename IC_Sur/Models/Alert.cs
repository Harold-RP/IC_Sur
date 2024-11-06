using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IC_Sur.Models
{
    public class Alert
    {
        [Key]
        public int AlertId { get; set; }

        [ForeignKey("Product")]
        [Display(Name = "Producto")]
        public int ProductId { get; set; }

        [Display(Name = "Producto")]
        public Product? Product { get; set; }

        [Required]
        [Display(Name = "Fecha de Alerta")]
        public DateTime AlertDate { get; set; }

        [Display(Name = "Estado")]
        public int Status { get; set; }
    }
}
