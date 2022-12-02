using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;
using WebProject.Contracts;
using WebProject.Data;
using WebProject.Data.Models;
using WebProject.Models.GameViewModel;

namespace WebProject.Services
{
    public class GameService : IGameService
    {
        private readonly GameStoreDbContext context;

        public GameService
            (GameStoreDbContext _context)
        {
            context = _context;
        }

        public async Task AddGameToStoreAsync(AddGameViewModel model)
        {
            var game = new Game()
            {
                GameName = model.GameName,
                Publisher = model.Publisher,
                Developer = model.Developer,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                ReleaseDate = model.ReleaseDate,
                Sales = model.FirstWeekSales,
                Price = model.Price,
                DiscountPrice = model.DiscountPrice,
                Rating = model.Rating
            };

            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();
        }

        public async Task AddToMyCartAsync(int gameId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UserGames)
                .FirstOrDefaultAsync();

            var game = await context.Games.FirstOrDefaultAsync(g => g.Id == gameId);

            if(user == null)
            {
                throw new ArgumentException("We couldnt find a user with such information");
            }

            if(game == null)
            {
                throw new ArgumentException("We couldnt find a game with such information");
            }

            if(!user.UserGames.Any(g => g.GameId == gameId))
            {
                user.UserGames.Add(new UserGame()
                {
                    UserId = user.Id,
                    User = user,
                    GameId = game.Id,
                    Game = game
                });

                await context.SaveChangesAsync();
            }

        }

        public void Delete(int gameId)
        {
            var game = context.Games.Find(gameId);

            context.Games.Remove(game);
            context.SaveChanges();
        }

        public void Edit(int gameId, string gameName, string developer, string publisher, string imageUrl, string description,
            DateTime releaseDate, int? firstWeekSales, decimal price, decimal? discountPrice, decimal rating, string? genre)
        {
            var game = context.Games.Find(gameId);

            game.GameName = gameName;
            game.Developer = developer;
            game.Publisher = publisher;
            game.Description = description;
            game.ImageUrl = imageUrl;
            game.ReleaseDate = releaseDate;
            game.Sales = firstWeekSales;
            game.Price = price;
            game.DiscountPrice = discountPrice;
            game.Rating = rating;
            game.Genre.Name = genre;

            context.SaveChanges();
        }

        public bool Exists(int gameId)
        {
            return context.Games.Any(g => g.Id == gameId);
        }

        public GameListViewModel GameDetailsById(int gameId)
        {
            var game = context.Games
                .Where(g => g.Id == gameId)
                .Select(g => new GameListViewModel()
                {
                    Id = g.Id,
                    GameName = g.GameName,
                    Developer = g.Developer,
                    Publisher = g.Publisher,
                    ImageUrl = g.ImageUrl,
                    Description = g.Description,
                    ReleaseDate = g.ReleaseDate,
                    Price = g.Price,
                    DiscountPrice = g.DiscountPrice,
                    FirstWeekSales = g.Sales,
                    Genre = g.Genre.Name,
                    Rating = g.Rating
                }).FirstOrDefault();

            return game;
        }

        public async Task<IEnumerable<Feature>> GetFeaturesAsync()
        {
            return await context.Features.ToListAsync();
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await context.Genres.ToListAsync();
        }

        public async Task<IEnumerable<GameListViewModel>> MyCartGamesAsync(string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UserGames)
                .ThenInclude(ug => ug.Game)
                .ThenInclude(g => g.Genre)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("We couldnt find a user with such information");
            }

            return user.UserGames
                .Select(g => new GameListViewModel()
                {
                    GameName = g.Game.GameName,
                    Publisher = g.Game.Publisher,
                    Developer = g.Game.Developer,
                    ImageUrl = g.Game.ImageUrl,
                    Id = g.Game.Id,
                    Genre = g.Game.Genre?.Name,
                    Description = g.Game.Description,
                    ReleaseDate = g.Game.ReleaseDate,
                    FirstWeekSales = g.Game.Sales,
                    Price = g.Game.Price,
                    DiscountPrice = g.Game.DiscountPrice,
                    Rating = g.Game.Rating
                });
        }

        public async Task RemoveFromMyCartAsync(int gameId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UserGames)
                .FirstOrDefaultAsync();


            if (user == null)
            {
                throw new ArgumentException("We couldnt find a user with such information");
            }

            var game = user.UserGames.FirstOrDefault(g => g.GameId == gameId);

            if(game != null)
            {
                user.UserGames.Remove(game);

                await context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<GameListViewModel>> ShowAllGamesAsync()
        {
            var games = await context.Games
                .Include(g => g.Genre)
                .ToListAsync();

            return games
                .Select(g => new GameListViewModel()
                {
                    GameName = g.GameName,
                    Publisher = g.Publisher,
                    Developer = g.Developer,
                    ImageUrl = g.ImageUrl,
                    Description = g.Description,
                    ReleaseDate = g.ReleaseDate,
                    FirstWeekSales = g.Sales,
                    Genre = g?.Genre?.Name,
                    Price = g.Price,
                    Id = g.Id,
                    DiscountPrice = g.DiscountPrice,
                    Rating = g.Rating
                });
        }
    }
}
