using System.ComponentModel.DataAnnotations;

namespace WebProject.Models.HealthProductViewModel
{
    public class AddHealthProductModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        public DateTime AvailableFrom { get; set; }

        [Range(typeof(decimal), "0.0", "350.0", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

        [Range(typeof(decimal), "0.0", "350.0", ConvertValueInInvariantCulture = true)]
        public decimal DiscountPrice { get; set; }

        [Range(typeof(decimal), "0.0", "10.0", ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }
    }
}
