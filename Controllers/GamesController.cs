using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebProject.Contracts;
using WebProject.Data;
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
    }
}
