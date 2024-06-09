using System;
using System.Collections.Generic;

namespace PrimerParcial.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual ICollection<ProductoCategoria> ProductoCategorias { get; set; }

    public virtual ICollection<Categorium> Categoria { get; set; } = new List<Categorium>();
}
