using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models.DTOs.Producto
{
    public class ProductoInsertDTO
    {

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(255, ErrorMessage = "El nombre no puede exceder los 255 caracteres.")]
        public required string Nombre { get; set; }

        public required string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser un valor no negativo.")]
        public int Stock { get; set; }
    }
}
