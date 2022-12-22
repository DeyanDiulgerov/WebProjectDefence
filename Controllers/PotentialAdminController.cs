using Microsoft.AspNetCore.Mvc;
using WebProject.Contracts;
using WebProject.Data;
using WebProject.Infrastructure;
using WebProject.Models.AdminViewModel;

namespace WebProject.Controllers
{
    public class PotentialAdminController : Controller
    {
        private readonly IAdminService adminService;
        private readonly GameStoreDbContext context;

        public PotentialAdminController
            (IAdminService _adminService,
            GameStoreDbContext _context)
        {
            adminService = _adminService;
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Become()
        {
            if (!adminService.IsAdmin(User.Id()))
            {
                return RedirectToAction(nameof(GamesController.All), "Games");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Become(BecomeAdminViewModel model)
        {
            var userId = User.Id();

            if (adminService.IsAdmin(userId))
            {
                return BadRequest();
            }

            if (adminService.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber),
                    "Phone number already exists. Enter another one to avoid confusion");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            adminService.Create(userId, model.PhoneNumber);

            return RedirectToAction(nameof(GamesController.All), "Games");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            if (!adminService.IsAdmin(User.Id()))
            {
                return RedirectToAction(nameof(GamesController.All), "Games");
            }
            var model = await adminService.potentialAdminsList();

            return View(model);
        }

        public IActionResult Approve(int adminId)
        {
            adminService.Approve(adminId);

            //return RedirectToAction(nameof(GamesController.All), "Games");
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (!adminService.IsAdmin(User.Id()))
            {
                return RedirectToAction(nameof(GamesController.All), "Games");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PotentialAdminViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!adminService.IsAdmin(User.Id()))
            {
                return RedirectToAction(nameof(GamesController.All), "Games");
            }

            try
            {
                await adminService.AddPotentialAdmin(model.UserId, model);

                return RedirectToAction("All", "Admins");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");

                return View(model);
            }
        }
    }
}
