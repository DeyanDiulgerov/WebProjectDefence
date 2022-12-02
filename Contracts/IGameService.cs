using WebProject.Data.Models;
using WebProject.Models.GameViewModel;

namespace WebProject.Contracts
{
    public interface IGameService
    {

        Task<IEnumerable<Feature>> GetFeaturesAsync();

        Task AddGameToStoreAsync(AddGameViewModel model);

        Task<IEnumerable<GameListViewModel>> ShowAllGamesAsync();

        Task<IEnumerable<GameListViewModel>> MyCartGamesAsync(string userId);

        Task AddToMyCartAsync(int gameId, string userId);

        Task RemoveFromMyCartAsync(int gameId, string userId);

        bool Exists(int gameId);

        GameListViewModel GameDetailsById(int gameId);

        void Edit(int gameId, string gameName, string developer, string publisher, string imageUrl, string description,
            DateTime releaseDate, int? firstWeekSales, decimal price, decimal? discountPrice, decimal rating, string? genre);

        void Delete(int gameId);
    }
}
