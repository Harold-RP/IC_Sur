using System.ComponentModel.DataAnnotations;

namespace IC_Sur.Models
{
    public class Provider
    {
        public int ProviderId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        [RegularExpression("^[0-9 +]+$", ErrorMessage = "Solo se permiten numeros y '+' en el campo ")]
        public string? PhoneNumber { get; set; }
        public string? ContactName { get; set; }

    }
}
