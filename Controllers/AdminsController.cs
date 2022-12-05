using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProject.Models.AgentsViewModels;

namespace WebProject.Controllers
{
    [Authorize]
    public class AdminsController : Controller
    {
        [HttpGet]
        public IActionResult Become()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Become(BecomeAdminViewModel model)
        {
            return RedirectToAction(nameof(GamesController.All), "Games");
        }
    }
}
