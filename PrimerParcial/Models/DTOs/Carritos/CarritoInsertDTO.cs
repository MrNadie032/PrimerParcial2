using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models.DTOs.Carritos
{
    public class CarritoInsertDTO
    {
        [ForeignKey("Cliente")]
        public int? ClienteId { get; set; }

        [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
        public DateTime Creado { get; set; }

        [Required(ErrorMessage = "La fecha de actualización es obligatoria.")]
        public DateTime Actualizado { get; set; }
    }
}
