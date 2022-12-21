using WebProject.Data;
using WebProject.Services.Statistics.Models;

namespace WebProject.Services.Statistics
{
    public class StatisticService : IStatisticService
    {
        private readonly GameStoreDbContext context;

        public StatisticService(GameStoreDbContext _context)
        {
            context = _context;
        }

        public StatisticsServiceModel Total()
        {
            var totalGames = context.Games.Count();
            var totalGamingProducts = context.GamingProducts.Count();
            var totalHealthyProducts = context.HealthProducts.Count();

            return new StatisticsServiceModel()
            {
                TotalGames = totalGames,
                TotalGamingProducts = totalGamingProducts,
                TotalHealthyProducts = totalHealthyProducts
            };
        }
    }
}
