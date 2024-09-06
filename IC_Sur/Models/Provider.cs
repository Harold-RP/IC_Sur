using System.ComponentModel.DataAnnotations;

namespace IC_Sur.Models
{
    public class Provider
    {
        public int ProviderId { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Solo se permiten letras en el campo nombre del proveedor.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre del Proveedor")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [StringLength(200, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres", MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Dirección del Proveedor")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [RegularExpression("^[0-9 +]+$", ErrorMessage = "Solo se permiten números y el símbolo '+' en el campo teléfono.")]
        [StringLength(15, ErrorMessage = "El {0} debe tener un máximo de {1} caracteres")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Número de Teléfono")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [StringLength(100, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Solo se permiten letras en el campo nombre del contacto.")]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre del Contacto")]
        public string? ContactName { get; set; }

    }
}
