using WebProject.Models.Enumerations;

namespace WebProject.Models.GameViewModel
{
    public class AllGamesQueryModel
    {
        // could Inherit GamesQueryModel (TotalGamesCount and Games)
        public const int GamesPerPage = 3;

        public string? SearchTerm { get; set; }

        public GameSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalGamesCount { get; set; }

        public IEnumerable<GameListViewModel> Games { get; set; } = Enumerable.Empty<GameListViewModel>();
    }
}
