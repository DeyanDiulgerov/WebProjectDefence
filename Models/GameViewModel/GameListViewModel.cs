using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebProject.Data.Models;
using System.ComponentModel;

namespace WebProject.Models.GameViewModel
{
    public class GameListViewModel : IGameModel
    {
        public int Id { get; set; }

        [DisplayName("Game name")]
        public string GameName { get; set; } = null!;

        public string Publisher { get; set; } = null!;

        [DisplayName("Image Url")]
        public string ImageUrl { get; set; } = null!;

        public string Developer { get; set; } = null!;

        public string Description { get; set; } = null!;

        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }

        [DisplayName("First week sales")]
        public int? FirstWeekSales { get; set; }

        public decimal Price { get; set; }

        [DisplayName("Discount Price")]
        public decimal? DiscountPrice { get; set; }

        public decimal Rating { get; set; }

        public string Genre { get; set; } = null!;
    }
}
