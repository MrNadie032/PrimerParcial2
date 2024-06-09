namespace PrimerParcial.Models.DTOs.Carritos
{
    public class CarritoGetDTO
    {
        public int Id { get; set; }

        public int? ClienteId { get; set; }

        public DateTime Creado { get; set; }

        public DateTime Actualizado { get; set; }
    }
}
