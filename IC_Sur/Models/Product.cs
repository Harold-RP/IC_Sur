using System.ComponentModel.DataAnnotations;

namespace IC_Sur.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio ")]
        [StringLength(60, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Solo se permiten letras en el campo nombre del producto.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre del Producto")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio ")]
        [StringLength(50, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Solo se permiten letras en el campo categoría del producto.")]
        [Display(Name = "Categoría del Producto")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio ")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El {0} debe ser mayor que 0")]
        [Display(Name = "Precio del Producto")]
        public double Price { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "El {0} no puede ser negativo")]
        [Display(Name = "Stock del Producto")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio ")]
        [StringLength(30, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres", MinimumLength = 2)]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Solo se permiten letras en el campo unidad de medida.")]
        [Display(Name = "Unidad de medida del Producto")]
        public string? MeasurementUnit { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [Display(Name = "Almacén del Producto")]
        public int StorageId { get; set; }
        public Storage? Storage { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [Display(Name = "Proveedor del Producto")]
        public int ProviderId { get; set; }
        public Provider? Provider { get; set; }
    }
}
