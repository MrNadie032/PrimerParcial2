using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models.DTOs.Pago
{
    public class PagoUpdateDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID del pedido es obligatorio.")]
        public int PedidoId { get; set; }

        [Required(ErrorMessage = "La fecha de pago es obligatoria.")]
        public DateTime FechaPago { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El monto debe ser un valor positivo.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El método de pago es obligatorio.")]
        [StringLength(50, ErrorMessage = "El método de pago no puede exceder los 50 caracteres.")]
        public required string Metodo { get; set; }

        [Required(ErrorMessage = "El estado del pago es obligatorio.")]
        [StringLength(50, ErrorMessage = "El estado del pago no puede exceder los 50 caracteres.")]
        public required string Estatus { get; set; }
    }
}
