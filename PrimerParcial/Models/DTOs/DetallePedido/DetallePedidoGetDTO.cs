﻿namespace PrimerParcial.Models.DTOs.DetallePedido
{
    public class DetallePedidoGetDTO
    {
        public int Id { get; set; }

        public int? PedidoId { get; set; }

        public int? ProductoId { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
    }
}
