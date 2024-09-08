using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC_Sur.Models
{
    public class EmployeePayment
    {
        [Key]
        public int EmployeePaymentId { get; set; }

        [ForeignKey("Employee")]
        [Display(Name = "Empleado")]
        public int EmployeeId { get; set; }

        [Display(Name = "Empleado")]
        public Employee? Employee { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The amount must be a positive value.")]
        [Display(Name = "Pago (Bs.)")]
        public double Amount { get; set; }

        [Required]
        [Display(Name = "Fecha/Hora de Pago")]
        public DateTime DateTimePayment { get; set; }

        [StringLength(500)]
        [Display(Name = "Detalle")]
        public string? Detail { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "The discount must be a positive value or null.")]
        [Display(Name = "Descuento (Bs.)")]
        public double? Discount { get; set; }
    }
}
