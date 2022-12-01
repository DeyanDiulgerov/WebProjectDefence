using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebProject.Data.Models;

namespace WebProject.Models.GameViewModel
{
    public class AddGameViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string GameName { get; set; } = null!;

        [Required]
        [StringLength(80, MinimumLength = 4)]
        public string Publisher { get; set; } = null!;

        [Required]
        [StringLength(80, MinimumLength = 4)]
        public string Developer { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        /*[ForeignKey(nameof(Developer))]
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; } = null!;*/

        [Required]
        [StringLength(500, MinimumLength = 0)]
        public string Description { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        public int FirstWeekSales { get; set; }

        [Range(typeof(decimal), "0.0", "350.0", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

        [Range(typeof(decimal), "0.0", "350.0", ConvertValueInInvariantCulture = true)]
        public decimal? DiscountPrice { get; set; }

        [Range(typeof(decimal), "0.0", "10.0", ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        public int GenreId { get; set; }
        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
    }
}
