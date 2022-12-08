using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProject.Contracts;
using WebProject.Data;
using WebProject.Infrastructure;
using WebProject.Models.AdminViewModel;

namespace WebProject.Controllers
{
    [Authorize]
    public class AdminsController : Controller
    {
        private readonly IAdminService adminService;
        private readonly GameStoreDbContext context;

        public AdminsController(IAdminService _adminService, GameStoreDbContext _context)
        {
            adminService = _adminService;
            context = _context;
        }

        [HttpGet]
        public IActionResult Become()
        {
            if(adminService.IsAdmin(this.User.Id()) || !User.Identity.IsAuthenticated || User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(GamesController.All), "Games");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Become(BecomeAdminViewModel model)
        {
            var userId = this.User.Id();

            if(adminService.IsAdmin(userId))
            {
                return BadRequest();
            }

            if(adminService.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber),
                    "Phone number already exists. Enter another one to avoid confusion");
            }

            if(!ModelState.IsValid)
            {
                return View(model);
            }

            adminService.Create(userId, model.PhoneNumber);

            return RedirectToAction(nameof(GamesController.All), "Games");
        }

        /*[HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await adminService.potentialAdminsList(this.User.Id());

            return View(model);
        }

        public async Task<IActionResult> Approve(string userId)
        {
            var admin = await adminService.Approve(userId);

            return RedirectToAction(nameof(GamesController.All), "Games");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PotentialAdminViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await adminService.AddPotentialAdmin(this.User.Id(), model);

                return RedirectToAction("All", "Admins");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }*/
    }
}
