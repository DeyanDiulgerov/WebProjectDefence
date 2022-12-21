using Microsoft.AspNetCore.Mvc;
using WebProject.Contracts;
using WebProject.Data;

namespace WebProject.Areas.Admin.Controllers
{
    public class UsersController : AdminController
    {
        private readonly IAdminService adminService;
        private readonly IAdminService result;

        public UsersController
            (IAdminService _adminService,
            GameStoreDbContext _context,
            IAdminService _result)
            : base(_adminService, _context)
        {
            adminService = _adminService;
            result = _result;
        }

        [Route("Users/All")]
        public IActionResult All()
        {
            var result = this.result.All();
            return View(result);
        }
    }
}
