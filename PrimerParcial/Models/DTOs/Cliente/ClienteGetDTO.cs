namespace PrimerParcial.Models.DTOs.Cliente
{
    public class ClienteGetDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Contrasena { get; set; } = null!;

        public string? Telefono { get; set; }
    }
}
