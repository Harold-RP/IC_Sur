using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IC_Sur.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }

        [RegularExpression("^[0-9 +]+$", ErrorMessage = "Solo se permiten numeros y '+' en el campo ")]
        public string? PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }

    }
}
