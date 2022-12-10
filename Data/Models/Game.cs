using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Data.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string GameName { get; set; } = null!;

        [Required]
        [StringLength(80)]
        public string Publisher { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        /*[ForeignKey(nameof(Developer))]
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; } = null!;*/

        [Required]
        public string Developer { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [Required]
        public string Genre { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        public int? Sales { get; set; }


        [Range(0.0, 350.0)]
        public decimal Price { get; set; }

        [Range(0.0, 350.0)]
        public decimal? DiscountPrice { get; set; }

        [Range(0.0, 10.0)]
        public decimal Rating { get; set; }


        /*public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();*/

        public IEnumerable<UserGame> UsersGames { get; set; } = new List<UserGame>();
    }
}
