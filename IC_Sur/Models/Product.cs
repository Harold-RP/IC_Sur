using System.ComponentModel.DataAnnotations;

namespace IC_Sur.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio ")]
        [StringLength(60, ErrorMessage = "{0} must be: minimum {2} and maxium {1} ", MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Solo se permiten letras en el campo nombre del producto.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre del Producto")]
        public string? Name { get; set; }

        [Display(Name = "Categoría del Producto")]
        public string? Category {  get; set; }
        
        [Required(ErrorMessage = "El Campo {0} es obligatorio ")]
        [Display(Name = "Precio del Producto")]
        public double Price { get; set; }

        [Display(Name = "Stock del Producto")]
        public int Stock {  get; set; }

        [Display(Name = "Unidad de medida del Producto")]
        public string? MeasurementUnit { get; set; }

        public int StorageId { get; set; }

        public int ProviderId { get; set; }
        //public ICollection<SaleProduct>? SaleProducts { get; set; }
    }
}
