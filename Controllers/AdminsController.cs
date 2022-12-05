using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProject.Contracts;
using WebProject.Infrastructure;
using WebProject.Models.AdminViewModel;

namespace WebProject.Controllers
{
    [Authorize]
    public class AdminsController : Controller
    {
        private readonly IAdminService adminService;

        public AdminsController(IAdminService _adminService)
        {
            adminService = _adminService;
        }

        [HttpGet]
        public IActionResult Become()
        {
            if(adminService.IsAdmin(this.User.Id()))
            {
                return BadRequest();
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
    }
}
