using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebProject.Contracts;
using WebProject.Models;

namespace WebProject.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        public ProductsController
            (IProductService _productService)
        {
            productService = _productService;
        }


        public async Task<IActionResult> All()
        {
            var model = await productService.AllProductsListAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new AddProductViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await productService.AddProductForSaleAsync(model);

                return RedirectToAction("All", "Products");
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
            var model = await productService.MyProductsAsync(userId);

            return View("MyCart", model);
        }

        public async Task<IActionResult> AddToCollection(int productId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await productService.AddProductToMyCollection(productId, userId);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromMyCollection(int productId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            await productService.RemoveFromMyCollection(productId, userId);

            return RedirectToAction(nameof(MyCart));
        }
    }
}
