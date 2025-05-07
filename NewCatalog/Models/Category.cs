using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace NewCatalog.Models
{
    public class Category
    {
        // Ключове значення
        [Key]
        public int Id { get; set; }

        // Ім'я категорії
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        // Батьківська категорія
        public int? ParentCategoryId { get; set; }

        // Підкатегорія
        [ForeignKey("ParentCategoryId")]
        public Category? ParentCategory { get; set; }





        public ICollection<Category>? Subcategories { get; set; }

        // Навігаційна властивість для товарів у категорії

        public ICollection<Product>? Products { get; set; }
    }
}
