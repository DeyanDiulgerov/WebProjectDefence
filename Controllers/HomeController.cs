using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebProject.Areas.Admin.Controllers;
using WebProject.Contracts;
using WebProject.Infrastructure;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdminService adminService;

        public HomeController(IAdminService _adminService)
        {
            adminService = _adminService;
        }

        public IActionResult Index()
        {
            /*if (this.User.Id() == "280cb06c-9c03-4481-ac1e-5da1be2ceece" ||
                this.User.Id() == "ea173d49-e1d8-4eed-b00c-33ae37c947e7" ||
                this.User.Id() == "dea12856-c198-4129-b3f3-b893d8395082")*/
            if(adminService.IsAdmin(this.User.Id()))
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }
            return View();
        }

        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}