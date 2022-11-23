using System.ComponentModel.DataAnnotations;
using WebProject.Data.Models;

namespace WebProject.Models
{
    public class AddProductViewModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(80)]
        public string Company { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        public DateTime AvailableFrom { get; set; }

        public int? Sales { get; set; }

        [Range(typeof(decimal), "0.0", "1000.0", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

        [Range(typeof(decimal), "0.0", "1000.0", ConvertValueInInvariantCulture = true)]
        public decimal DiscountPrice { get; set; }
    }
}
