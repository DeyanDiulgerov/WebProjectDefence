using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebProject.Data.Models;
using System.ComponentModel;

namespace WebProject.Models.GameViewModel
{
    public class AddGameViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DisplayName("Game name")]
        public string GameName { get; set; } = null!;

        [Required]
        [StringLength(80, MinimumLength = 4)]
        public string Publisher { get; set; } = null!;

        [Required]
        [StringLength(80, MinimumLength = 4)]
        public string Developer { get; set; } = null!;

        [Required]
        [DisplayName("Image Url")]
        public string ImageUrl { get; set; } = null!;

        /*[ForeignKey(nameof(Developer))]
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; } = null!;*/

        [Required]
        [StringLength(500, MinimumLength = 0)]
        public string Description { get; set; } = null!;

        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }

        [DisplayName("First week sales")]
        public int FirstWeekSales { get; set; }

        [Range(typeof(decimal), "0.0", "350.0", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

        [Range(typeof(decimal), "0.0", "350.0", ConvertValueInInvariantCulture = true)]
        [DisplayName("Discount Price")]
        public decimal? DiscountPrice { get; set; }

        [Range(typeof(decimal), "0.0", "10.0", ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required]
        public string Genre { get; set; } = null!;
    }
}
