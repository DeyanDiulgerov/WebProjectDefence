using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Policy;
using WebProject.Contracts;
using WebProject.Data;
using WebProject.Data.Models;
using WebProject.Models.GameViewModel;

namespace WebProject.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private readonly IGameService gameService;
        private readonly GameStoreDbContext context;

        public GamesController
            (IGameService _gameService,
            GameStoreDbContext _context)
        {
            gameService = _gameService;
            context = _context;
        }


        public async Task<IActionResult> All()
        {
            var model = await gameService.ShowAllGamesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddGameViewModel()
            {
                Genres = await gameService.GetGenresAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddGameViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await gameService.AddGameToStoreAsync(model);

                return RedirectToAction("All", "Games");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }

        public async Task<IActionResult> MyCart()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await gameService.MyCartGamesAsync(userId);

            return View("MyCart", model);
        }

        public async Task<IActionResult> AddToCollection(int gameId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await gameService.AddToMyCartAsync(gameId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromMyCollection(int gameId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await gameService.RemoveFromMyCartAsync(gameId, userId);

            return RedirectToAction(nameof(MyCart));
        }

        public IActionResult Details(int gameId)
        {
            if (!gameService.Exists(gameId))
            {
                return BadRequest();
            }

            var gameModel = gameService.GameDetailsById(gameId);

            return View(gameModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!gameService.Exists(id))
            {
                return BadRequest();
            }

            var game = gameService.GameDetailsById(id);

            var gameModel = new GameListViewModel()
            {
                GameName = game.GameName,
                Developer = game.Developer,
                Publisher = game.Publisher,
                Description = game.Description,
                ImageUrl = game.ImageUrl,
                ReleaseDate = game.ReleaseDate,
                FirstWeekSales = game.FirstWeekSales,
                Price = game.Price,
                DiscountPrice = game.DiscountPrice,
                Rating = game.Rating,
                Genre = game.Genre,
            };

            return View(gameModel);
        }

        [HttpPost]
        public IActionResult Edit(int Id, GameListViewModel model)
        {
            if (!gameService.Exists(Id))
            {
                return View();
            }

            if(!ModelState.IsValid)
            {
                return View(model);
            }

            gameService.Edit(Id, model.GameName, model.Developer, model.Publisher, model.ImageUrl
                , model.Description, model.ReleaseDate, model.FirstWeekSales, model.Price, model.DiscountPrice,
                model.Rating, model.Genre);

            return RedirectToAction(nameof(Details), new { id = Id });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(!gameService.Exists(id))
            {
                return BadRequest();
            }

            var game = gameService.GameDetailsById(id);

            var gameModel = new GameListViewModel()
            {
                GameName = game.GameName,
                Developer = game.Developer,
                Publisher = game.Publisher,
                Description = game.Description,
                ImageUrl = game.ImageUrl,
                ReleaseDate = game.ReleaseDate,
                FirstWeekSales = game.FirstWeekSales,
                Price = game.Price,
                DiscountPrice = game.DiscountPrice,
                Rating = game.Rating,
                Genre = game.Genre,
            };

            return View(gameModel);
        }

        [HttpPost]
        public IActionResult Delete(GameListViewModel model)
        {
            if (!gameService.Exists(model.Id))
            {
                return BadRequest();
            }

            gameService.Delete(model.Id);

            return RedirectToAction(nameof(All));
        }
    }
}
