using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Models
{
    public class ProductoCategoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categorium Categoria { get; set; }
    }
}
