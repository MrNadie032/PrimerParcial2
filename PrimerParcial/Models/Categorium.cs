using System;
using System.Collections.Generic;

namespace PrimerParcial.Models;

public partial class Categorium
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<ProductoCategoria> ProductoCategorias { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
