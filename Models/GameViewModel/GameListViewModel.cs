using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebProject.Data.Models;

namespace WebProject.Models.GameViewModel
{
    public class GameListViewModel
    {
        public int Id { get; set; }

        public string GameName { get; set; } = null!;

        public string Publisher { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Developer { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        public int? FirstWeekSales { get; set; }

        public decimal Price { get; set; }

        public decimal? DiscountPrice { get; set; }

        public decimal Rating { get; set; }

        public string? Genre { get; set; }
    }
}
