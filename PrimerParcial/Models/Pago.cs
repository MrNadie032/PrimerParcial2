using System;
using System.Collections.Generic;

namespace PrimerParcial.Models;

public partial class Pago
{
    public int Id { get; set; }

    public int? PedidoId { get; set; }

    public DateTime FechaPago { get; set; }

    public decimal Monto { get; set; }

    public string Metodo { get; set; } = null!;

    public string Estatus { get; set; } = null!;

    public virtual Pedido? Pedido { get; set; }
}
