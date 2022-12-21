using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebProject.Contracts;
using WebProject.Data;
using WebProject.Data.Models;

namespace WebProject.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {

        public HomeController
            (IAdminService _adminService, 
            GameStoreDbContext _context)
            : base(_adminService, _context)
        {
        }

       /* public IActionResult Index()
        {
            return View();
        }*/
    }
}
