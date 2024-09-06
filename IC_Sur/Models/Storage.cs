using System.ComponentModel.DataAnnotations;

namespace IC_Sur.Models
{
    public class Storage
    {
        public int StorageId { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Solo se permiten letras y números en el campo sección del almacén.")]
        [Display(Name = "Sección del Almacén")]
        public string Section { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [StringLength(200, ErrorMessage = "El {0} debe tener entre {2} y {1} caracteres", MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Ubicación del Almacén")]
        public string Location { get; set; }

        public ICollection<Product>? Products { get; set; }

    }
}
