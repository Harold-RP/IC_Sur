using System.ComponentModel.DataAnnotations;

namespace IC_Sur.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "El nombre del rol es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre del rol no puede exceder los 50 caracteres.")]
        [Display(Name = "Rol")]
        public string? RoleName { get; set; }

        [Required(ErrorMessage = "El salario es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El salario debe ser un valor positivo.")]
        [Display(Name = "Sueldo")]
        public double Salary { get; set; }
    }
}
