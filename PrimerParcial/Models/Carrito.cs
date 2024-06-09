using System;
using System.Collections.Generic;

namespace PrimerParcial.Models;

public partial class Carrito
{
    public int Id { get; set; }

    public int? ClienteId { get; set; }

    public DateTime Creado { get; set; }

    public DateTime Actualizado { get; set; }

    public virtual Cliente? Cliente { get; set; }
}
