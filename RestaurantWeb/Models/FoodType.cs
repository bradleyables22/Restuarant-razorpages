using System.ComponentModel.DataAnnotations;

namespace RestaurantWeb.Models
{
    public class FoodType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
