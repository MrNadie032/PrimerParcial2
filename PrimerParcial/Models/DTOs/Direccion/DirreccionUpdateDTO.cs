using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models.DTOs.Direccion
{
    public class DirreccionUpdateDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "La calle es obligatoria.")]
        [StringLength(255, ErrorMessage = "La calle no puede exceder los 255 caracteres.")]
        public required string Calle { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria.")]
        [StringLength(100, ErrorMessage = "La ciudad no puede exceder los 100 caracteres.")]
        public required string Ciudad { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [StringLength(100, ErrorMessage = "El estado no puede exceder los 100 caracteres.")]
        public required string Estado { get; set; }

        [Required(ErrorMessage = "El código postal es obligatorio.")]
        [StringLength(20, ErrorMessage = "El código postal no puede exceder los 20 caracteres.")]
        public required string CodigoPostal { get; set; }

        [Required(ErrorMessage = "El país es obligatorio.")]
        [StringLength(100, ErrorMessage = "El país no puede exceder los 100 caracteres.")]
        public required string Pais { get; set; }
    }
}
