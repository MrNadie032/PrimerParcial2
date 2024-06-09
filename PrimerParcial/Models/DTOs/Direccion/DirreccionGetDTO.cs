namespace PrimerParcial.Models.DTOs.Direccion
{
    public class DirreccionGetDTO
    {
        public int Id { get; set; }

        public int? ClienteId { get; set; }

        public string Calle { get; set; } = null!;

        public string Ciudad { get; set; } = null!;

        public string Estado { get; set; } = null!;

        public string CodigoPostal { get; set; } = null!;

        public string Pais { get; set; } = null!;
    }
}
