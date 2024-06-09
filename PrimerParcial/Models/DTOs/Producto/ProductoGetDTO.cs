namespace PrimerParcial.Models.DTOs.Producto
{
    public class ProductoGetDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }
    }
}
