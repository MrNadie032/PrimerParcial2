namespace PrimerParcial.Models.DTOs.Pedido
{
    public class PedidoGetDTO
    {
        public int Id { get; set; }

        public int? ClienteId { get; set; }

        public DateTime FechaPedido { get; set; }

        public string Estado { get; set; } = null!;

        public decimal Total { get; set; }
    }
}
