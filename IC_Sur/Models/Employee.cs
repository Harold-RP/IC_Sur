using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC_Sur.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        [Display(Name = "Nombre(s)")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100, ErrorMessage = "El apellido no puede exceder los 100 caracteres.")]
        [Display(Name = "Apellidos")]
        public string? LastName { get; set; }

        [StringLength(200, ErrorMessage = "La dirección no puede exceder los 200 caracteres.")]
        [Display(Name = "Dirección")]
        public string? Address { get; set; }

        [RegularExpression("^[0-9 +]+$", ErrorMessage = "Solo se permiten números y '+' en el campo de teléfono.")]
        [StringLength(20, ErrorMessage = "El número de teléfono no puede exceder los 20 caracteres.")]
        [Display(Name = "Número Telefónico")]
        public string? PhoneNumber { get; set; }

        [ForeignKey("Role")]
        [Display(Name = "Rol")]
        public int RoleId { get; set; }

        [Display(Name = "Rol")]
        public Role? Role { get; set; }
    }
}
