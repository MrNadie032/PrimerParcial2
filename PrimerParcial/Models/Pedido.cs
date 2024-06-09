using System;
using System.Collections.Generic;

namespace PrimerParcial.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public int? ClienteId { get; set; }

    public DateTime FechaPedido { get; set; }

    public string Estado { get; set; } = null!;

    public decimal Total { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
