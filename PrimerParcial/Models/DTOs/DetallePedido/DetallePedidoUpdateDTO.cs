using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models.DTOs.DetallePedido
{
    public class DetallePedidoUpdateDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID del pedido es obligatorio.")]
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "El ID del producto es obligatorio.")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
        public decimal Precio { get; set; }
    }
}
