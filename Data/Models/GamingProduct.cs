using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Data.Models
{
    public class GamingProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(80)]
        public string Company { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        public DateTime AvailableFrom { get; set; }

        public int? Sales { get; set; }

        [Range(0.0, 1000.0)]
        public decimal Price { get; set; }

        [Range(0.0, 1000.0)]
        public decimal DiscountPrice { get; set; }

        public IEnumerable<UserGamingProduct> UsersGamingProducts { get; set; } = new List<UserGamingProduct>();
    }
}
