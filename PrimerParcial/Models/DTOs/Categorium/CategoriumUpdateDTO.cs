using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models.DTOs.Categorium
{
    public class CategoriumUpdateDTO
    {
        [Required(ErrorMessage = "Id es requerido")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        [MaxLength(100, ErrorMessage = "Nombre no puede ser mayor a 100 carácteres")]
        public string Nombre { get; set; } = null!;
    }
}
