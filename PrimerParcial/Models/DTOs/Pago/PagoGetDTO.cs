namespace PrimerParcial.Models.DTOs.Pago
{
    public class PagoGetDTO
    {
        public int Id { get; set; }

        public int? PedidoId { get; set; }

        public DateTime FechaPago { get; set; }

        public decimal Monto { get; set; }

        public string Metodo { get; set; } = null!;

        public string Estatus { get; set; } = null!;
    }
}
