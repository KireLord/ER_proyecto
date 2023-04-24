using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ER_proyecto.Models
{
    public class ER_Tabla
    {
        [Key]
        public int Cedula { get; set; }
        [Required]
        [Range(0.01,9999.99)]
        public decimal Precio { get; set; }
        [Required]
        [StringLength(10)]
        public String? Nombre { get; set; }
        public bool AceptarTerminos { get; set; }
        [Required]
        public DateTime? Tiempo { get; set; }
    }
}
