namespace WebProject.Models.GameViewModel
{
    public class GamesQueryModel
    {
        public int TotalGamesCount { get; set; }

        public IEnumerable<GameListViewModel> Games { get; set; } = new List<GameListViewModel>();
    }
}
