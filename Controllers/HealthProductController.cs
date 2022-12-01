using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebProject.Contracts;
using WebProject.Models.HealthProductViewModel;

namespace WebProject.Controllers
{
    [Authorize]
    public class HealthProductController : Controller
    {
        private readonly IHealthProductService healthProductService;

        public HealthProductController
            (IHealthProductService _healthProductService)
        {
            this.healthProductService = _healthProductService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await healthProductService.ShowAllProducts();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new AddHealthProductModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddHealthProductModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await healthProductService.AddHealthProduct(model);

                return RedirectToAction("All", "HealthProduct");
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
            var model = await healthProductService.ShowMyProducts(userId);

            return View("MyCart", model);
        }

        public async Task<IActionResult> AddToCollection(int productId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await healthProductService.AddToCollection(productId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("All", "HealthProduct");
        }

        public async Task<IActionResult> RemoveFromCollection(int productId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await healthProductService.RemoveFromCollection(productId, userId);

            return RedirectToAction(nameof(MyCart));
        }

        public IActionResult Details(int productId)
        {
            if(!healthProductService.Exists(productId))
            {
                return BadRequest();
            }

            var productModel = healthProductService.ProductDetailsById(productId);

            return View(productModel);
        }
    }
}
