using WebProject.Data.Models;
using WebProject.Models;

namespace WebProject.Contracts
{
    public interface IGameService
    {
        Task<IEnumerable<Genre>> GetGenresAsync();

        Task<IEnumerable<Feature>> GetFeaturesAsync();

        Task AddGameToStoreAsync(AddGameViewModel model);

        Task<IEnumerable<GameListViewModel>> ShowAllGamesAsync();

        Task<IEnumerable<GameListViewModel>> MyCartGamesAsync(string userId);

        Task AddToMyCartAsync(int gameId, string userId);

        Task RemoveFromMyCartAsync(int gameId, string userId);
    }
}
