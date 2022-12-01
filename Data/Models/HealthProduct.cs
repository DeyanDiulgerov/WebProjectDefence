using System.ComponentModel.DataAnnotations;

namespace WebProject.Data.Models
{
    public class HealthProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        public DateTime AvailableFrom { get; set; }

        [Range(0.0, 350.0)]
        public decimal Price { get; set; }

        [Range(0.0, 350.0)]
        public decimal DiscountPrice { get; set; }

        [Range(0.0, 10.0)]
        public decimal Rating { get; set; }

        public IEnumerable<UserHealthProduct> UsersHealthProducts { get; set; } = new List<UserHealthProduct>();
    }
}
