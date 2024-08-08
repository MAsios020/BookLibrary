using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter vaild Value")]
        [DisplayName("Display Order")]
        [Range(1, 500, ErrorMessage = "The Range of Display order between 1 to 500")]
        public int DisplayOrder { get; set; }
    }
}
