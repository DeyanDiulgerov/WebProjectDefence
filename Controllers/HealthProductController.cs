using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebProject.Contracts;
using WebProject.Models.GamingProductViewModel;
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
        public async Task<IActionResult> All([FromQuery]AllHealthQueryModel query)
        {
            var result = await healthProductService.ShowAllProducts(
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllHealthQueryModel.HealthyProudctsPerPage);

            query.TotalHealthProductsCount = result.TotalHealthProductsCount;
            query.HealthProducts = result.HealthProducts;

            return View(query);
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

        public IActionResult MyCartDetails(int productId)
        {
            if (!healthProductService.Exists(productId))
            {
                return BadRequest();
            }

            var productModel = healthProductService.ProductDetailsById(productId);

            return View(productModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(!healthProductService.Exists(id))
            {
                return BadRequest();
            }

            var healthProduct = healthProductService.ProductDetailsById(id);

            var healthProductModel = new HealthProductListViewModel()
            {
                Name = healthProduct.Name,
                ImageUrl = healthProduct.ImageUrl,
                Description = healthProduct.Description,
                AvailableFrom = healthProduct.AvailableFrom,
                Price = healthProduct.Price,
                DiscountPrice = healthProduct.DiscountPrice,
                Rating = healthProduct.Rating
            };

            return View(healthProductModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, HealthProductListViewModel model)
        {
            if (!healthProductService.Exists(id))
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return View(model);
            }

            healthProductService.Edit(id, model.Name, model.ImageUrl, model.Description, model.AvailableFrom,
                model.Price, model.DiscountPrice, model.Rating);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(!healthProductService.Exists(id))
            {
                return BadRequest();
            }

            var healthProduct = healthProductService.ProductDetailsById(id);

            var healthProductModel = new HealthProductListViewModel()
            {
                Name = healthProduct.Name,
                ImageUrl = healthProduct.ImageUrl,
                Description = healthProduct.Description,
                AvailableFrom = healthProduct.AvailableFrom,
                Price = healthProduct.Price,
                DiscountPrice = healthProduct.DiscountPrice,
                Rating = healthProduct.Rating
            };

            return View(healthProductModel);
        }

        [HttpPost]
        public IActionResult Delete(HealthProductListViewModel model)
        {
            if (!healthProductService.Exists(model.Id))
            {
                return BadRequest();
            }

            healthProductService.Delete(model.Id);

            return RedirectToAction(nameof(All));
        }
    }
}
