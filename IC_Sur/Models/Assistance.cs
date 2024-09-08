using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IC_Sur.Models
{
    public class Assistance
    {
        [Key]
        public int AssistanceId { get; set; }

        [ForeignKey("Employee")]
        [Display(Name = "Empleado")]
        public int EmployeeId { get; set; }

        [Display(Name = "Empleado")]
        public Employee? Employee { get; set; }

        [Required]
        [Display(Name = "Fecha/Hora de Llegada")]
        public DateTime ArrivalDatetime { get; set; }

        [Display(Name = "Fecha/Hora de Salida")]
        public DateTime? ExitDateTime { get; set; }

        [StringLength(50)]
        [Display(Name = "Asistencia")]
        public string? AssistanceMark { get; set; }
    }
}
