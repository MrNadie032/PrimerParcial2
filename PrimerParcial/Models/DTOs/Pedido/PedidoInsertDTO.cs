using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models.DTOs.Pedido
{
    public class PedidoInsertDTO
    {

        [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "La fecha del pedido es obligatoria.")]
        public DateTime FechaPedido { get; set; }

        [Required(ErrorMessage = "El estado del pedido es obligatorio.")]
        [StringLength(50, ErrorMessage = "El estado no puede exceder los 50 caracteres.")]
        public required string Estado { get; set; }

        [Required(ErrorMessage = "El total del pedido es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El total debe ser un valor positivo.")]
        public decimal Total { get; set; }
    }
}
