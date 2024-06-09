using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models.DTOs.Categorium
{
    public class CategoriumInsertDTO
    {
       
        [Required(ErrorMessage = "Nombre es requerido")]
        [MaxLength(100, ErrorMessage = "Nombre no puede ser mayor a 100 carácteres")]
        public string Nombre { get; set; } = null!;
    }
}
