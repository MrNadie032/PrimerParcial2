using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models.DTOs.Cliente
{
    public class ClienteInsertDTO
    {

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(255, ErrorMessage = "El nombre no puede exceder los 255 caracteres.")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [StringLength(255, ErrorMessage = "El correo electrónico no puede exceder los 255 caracteres.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(100, ErrorMessage = "La contraseña no puede exceder los 255 caracteres.")]
        public required string Contrasena { get; set; }

        [StringLength(10, ErrorMessage = "El teléfono no puede exceder los 20 caracteres.")]
        public required string Telefono { get; set; }
    }
}
