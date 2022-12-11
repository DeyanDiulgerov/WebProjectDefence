using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Contracts;
using WebProject.Data.Models;
using WebProject.Models.GameViewModel;
using WebProject.Services;

namespace WebProject.Tests.UnitTests
{
    [TestFixture]
    public class GameServiceTests : UnitTestsBase
    {
        private IGameService gameService;

        [OneTimeSetUp]
        public void SetUp()
            => this.gameService = new GameService(context);

        [Test]
        public void GetGameId_ShouldReturnCorrectGameId()
        {
            // Arrange

            // Act: Invoke the service method with valid id
            var resultGameId = gameService.GameDetailsById(this.Game.Id);

            // Assert a correct id is returned
            Assert.That(this.Game.Id, Is.EqualTo(1));
        }

        [Test]
        public void GameExistsInDb_ShouldReturnIfGameExistsById()
        {
            // Arrange

            // Act: Invoke the service method with valid id
            var resultGameId = gameService.Exists(this.Game.Id);

            // Assert a correct id is returned
            Assert.IsTrue(resultGameId);
        }

        [Test]
        public void GameDetailsById_ShouldReturnCorrectGameData()
        {
            // Arrange: get a valid rented game id
            var gameId = this.Game.Id;

            // Act: Invoke the service method with the valid id
            var result = gameService.GameDetailsById(gameId);

            // Assert the returned result is not null
            Assert.IsNotNull(result);

            // Assert the returned data is correct
            var gameInDb = context.Games.Find(gameId);
            Assert.That(result.Id, Is.EqualTo(gameInDb.Id));
            Assert.That(result.GameName, Is.EqualTo(gameInDb.GameName));
        }

        [Test]
        public void Add_ShouldCreateGame()
        {

            // Arrange: create a new Game variable with needed data
            var newGame = new AddGameViewModel()
            {
                Developer = "Third TestDeveloper",
                Publisher = "Third TestPublisher",
                Description = "Third TestDescription",
                GameName = "Third TestName",
                Price = 10.0m,
                DiscountPrice = 7.0m,
                Genre = "Third TestGenre",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQE71yLKH6QqyuwnY02KokINKViHp3R2wn2Ng&usqp=CAU",
                Rating = 8.90m,
                ReleaseDate = DateTime.UtcNow,
                FirstWeekSales = 25
            };

            // Act: invoke the service method with neccessary valid data
            var newGameId = gameService.AddGameToStoreAsync(newGame);

            /*var newGameId = gameService.AddGameToStoreAsync(newGame.GameName, newGame.Developer, newGame.Publisher, newGame.Description,
                newGame.Price, newGame.DiscountPrice, newGame.Genre, newGame.ImageUrl, newGame.Rating, newGame.ReleaseDate, newGame.Sales);*/

            // Arrange: get the games current count
            var gamesInDbBefore = context.Games.Count();

            // Assert the games correct count has increased by 1
            var gamesInDbAfter = context.Games.Count();
            Assert.That(gamesInDbAfter, Is.EqualTo(gamesInDbBefore));

            // Assert the new game is created with correct data
            var newGameInDb = context.Games.Find(3);
            Assert.That(newGameInDb.GameName, Is.EqualTo(newGame.GameName));
        }

        [Test]
        public void GameToCollection_ShouldAddGameToMyCollection()
        {
            var userId = this.User.Id;
            var gameId = this.Game.Id;

            var gamesInUserGameBefore = this.User.UserGames.Count();

            this.User.UserGames.Add(new UserGame()
            {
                UserId = this.User.Id,
                User = this.User,
                Game = this.Game,
                GameId = this.Game.Id
            });

            context.Games.Add(this.Game);


            gameService.AddToMyCartAsync(gameId, userId);

            var gamesInUserGameAfter = this.User.UserGames.Count();

            Assert.That(gamesInUserGameAfter, Is.EqualTo(gamesInUserGameBefore + 1));

            var newGameInUserGames = this.User.UserGames.FirstOrDefault(x => x.GameId == gameId);

            Assert.That(newGameInUserGames, Is.Not.Null);
            Assert.That(newGameInUserGames.Game.GameName, Is.EqualTo(this.Game.GameName));
            Assert.That(newGameInUserGames.Game.Id, Is.EqualTo(gameId));
        }

        [Test]
        public void DeleteGameFromCollection_ShouldDeleteGameFromMyCollection()
        {
            var userId = this.User.Id;
            var gameId = this.Game.Id;
        
            this.User.UserGames.Add(new UserGame()
            {
                UserId = this.User.Id,
                User = this.User,
                Game = this.Game,
                GameId = this.Game.Id
            });

            var userGame = this.User.UserGames.FirstOrDefault(x => x.GameId == gameId);

            // check how many games in my collection
            var gamesInUserGameBefore = this.User.UserGames.Count();

            // remove from my collection
            this.User.UserGames.Remove(userGame);

            gameService.RemoveFromMyCartAsync(gameId, userId);

            var gamesInUserGameAfter = this.User.UserGames.Count();

            Assert.That(gamesInUserGameAfter, Is.EqualTo(gamesInUserGameBefore - 1));

            var removedGameFromUserGames = this.User.UserGames.FirstOrDefault(x => x.GameId == gameId);

            Assert.IsNull(removedGameFromUserGames);
        }

        [Test]
        public void Edit_ShouldEditGameCorrectly()
        {
            // Arrange: add a new game to the database
            var newGame = new Game()
            {
                Id = 44,
                Developer = "Fourth TestDeveloper",
                Publisher = "Fourth TestPublisher",
                Description = "Fourth TestDescription",
                GameName = "Fourth TestName",
                Price = 10.0m,
                DiscountPrice = 7.0m,
                Genre = "Fourth TestGenre",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQE71yLKH6QqyuwnY02KokINKViHp3R2wn2Ng&usqp=CAU",
                Rating = 8.90m,
                ReleaseDate = DateTime.UtcNow,
                Sales = 25
            };

            context.Games.Add(newGame);
            context.SaveChanges();

            var changedName = "TestTest";

            // Act: Invoke the method with the valid data and changed name
            gameService.Edit(newGame.Id, changedName, newGame.Developer, newGame.Publisher, newGame.ImageUrl,
                newGame.Description, newGame.ReleaseDate, newGame.Sales, newGame.Price, newGame.DiscountPrice,
                newGame.Rating, newGame.Genre);

            context.SaveChanges();

            // Assert the game data in the database is correct
            var newGameInDb = context.Games.Find(newGame.Id);
            Assert.IsNotNull(newGameInDb);
            Assert.That(newGameInDb.GameName, Is.EqualTo(changedName));
            Assert.That(newGameInDb.Id, Is.EqualTo(newGame.Id));

            context.Games.Remove(newGame);
        }

        [Test]
        public void Delete_ShouldDeleteGameSuccessfully()
        {
            // Arrange: add a new game to the database
            var newGame = new Game()
            {
                Developer = "Third TestDeveloper",
                Publisher = "Third TestPublisher",
                Description = "Third TestDescription",
                GameName = "Third TestName",
                Price = 10.0m,
                DiscountPrice = 7.0m,
                Genre = "Third TestGenre",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQE71yLKH6QqyuwnY02KokINKViHp3R2wn2Ng&usqp=CAU",
                Rating = 8.90m,
                ReleaseDate = DateTime.UtcNow,
                Sales = 25
            };

            context.Games.Add(newGame);
            context.SaveChanges();

            // Arrange: get the current game's count
            var gamesCountBefore = context.Games.Count();

            // Act: Invoke the method with valid id
            gameService.Delete(newGame.Id);

            // Assert: games count has decreasead by 1
            var gamesCountAfter = context.Games.Count();
            Assert.That(gamesCountAfter, Is.EqualTo(gamesCountBefore - 1));

            // Assert the game is not present in Db
            var newGameInDb = context.Games.Find(newGame.Id);
            Assert.IsNull(newGameInDb);
        }

        [Test]
        public void AllGamesShowcase_ShouldShowAllGamesCorrectly()
        {
            var games = gameService.ShowAllGamesAsync();
            Assert.IsNotNull(games);
        }

        [Test]
        public void MyCartAllGamesShowcase_ShouldShowAllUserGamesCorrectly()
        {
            this.User.UserGames.Add(new UserGame()
            {
                UserId = this.User.Id,
                User = this.User,
                Game = this.Game,
                GameId = this.Game.Id
            });

            var games = gameService.MyCartGamesAsync(this.User.Id);
            Assert.IsNotNull(games);
        }
    }
}
