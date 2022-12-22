using Microsoft.AspNetCore.Mvc;
using WebProject.Contracts;
using WebProject.Data;
using WebProject.Data.Models;
using WebProject.Models.GameViewModel;
using WebProject.Services;

namespace WebProject.Areas.Admin.Controllers
{
    public class UsersController : AdminController
    {
        private readonly IAdminService adminService;
        private readonly IAdminService result;
        private readonly GameStoreDbContext context;

        public UsersController
            (IAdminService _adminService,
            GameStoreDbContext _context,
            IAdminService _result)
            : base(_adminService, _context)
        {
            adminService = _adminService;
            result = _result;
            context = _context;
        }

        [Route("Users/All")]
        public IActionResult AllUsers()
        {
            var result = this.result.All();
            return View(result);
        }
    }
}
