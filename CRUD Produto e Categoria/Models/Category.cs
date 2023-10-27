using System.ComponentModel.DataAnnotations;

namespace CRUD_Produto_e_Categoria.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string? Name { get; set; }
        public List<ProductCategory>? Products { get; set; }
    }
}
