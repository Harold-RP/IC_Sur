using System.ComponentModel.DataAnnotations;

namespace IC_Sur.Models
{
    public class StorageEntry
    {
        public int StorageEntryId { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [Display(Name = "Fecha y Hora de Entrada")]
        [DataType(DataType.DateTime)]
        public DateTime EntryDateTime { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [Display(Name = "Producto")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [Display(Name = "Proveedor")]
        public int ProviderId { get; set; }
        public Provider? Provider { get; set; }

        [Required(ErrorMessage = "El Campo {0} es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1")]
        [Display(Name = "Cantidad del Producto")]
        public int ProductAmount { get; set; }
    }
}
