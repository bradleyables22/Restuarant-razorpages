using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restuarant.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Display Order")]
        [Range(1, 100, ErrorMessage = "Display range must be between 1 and 100.")]
        public int DisplayOrder { get; set; }
    }
}
