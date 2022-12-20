﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebProject.Contracts;
using WebProject.Models.GameViewModel;
using WebProject.Models.GamingProductViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebProject.Controllers
{
    [Authorize]
    public class GamingProductsController : Controller
    {
        private readonly IGamingProductService productService;
        public GamingProductsController
            (IGamingProductService _productService)
        {
            productService = _productService;
        }


        public async Task<IActionResult> All([FromQuery]AllGamingProductsQueryModel query)
        {
            var result = await productService.AllProductsListAsync(
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllGamingProductsQueryModel.ProductsPerPage);

            query.TotalGamingProductsCount = result.TotalGamingProductsCount;
            query.GamingProducts = result.GamingProducts;

            return View(query);
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

                return RedirectToAction("All", "GamingProducts");
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

        public IActionResult Details(int productId)
        {
            if(!productService.Exists(productId))
            {
                return BadRequest();
            }

            var productModel = productService.ProductDetailsById(productId);

            return View(productModel);
        }

        public IActionResult MyCartDetails(int productId)
        {
            if (!productService.Exists(productId))
            {
                return BadRequest();
            }

            var productModel = productService.ProductDetailsById(productId);

            return View(productModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(!productService.Exists(id))
            {
                return BadRequest();
            }

            var product = productService.ProductDetailsById(id);

            var productModel = new ProductListViewModel()
            {
                Name = product.Name,
                Company = product.Company,
                Description = product.Description,
                AvailableFrom = product.AvailableFrom,
                Price = product.Price,
                DiscountPrice = product.DiscountPrice,
                ImageUrl = product.ImageUrl,
                Sales = product.Sales
            };

            return View(productModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, ProductListViewModel model)
        {
            if (!productService.Exists(id))
            {
                return View();
            }

            if(!ModelState.IsValid)
            {
                return View(model);
            }

            productService.Edit(id, model.Name, model.Company, model.ImageUrl, model.Description,
                model.AvailableFrom, model.Sales, model.Price, model.DiscountPrice);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(!productService.Exists(id))
            {
                return BadRequest();
            }

            var product = productService.ProductDetailsById(id);

            var productModel = new ProductListViewModel()
            {
                Name =product.Name,
                Company = product.Company,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                AvailableFrom = product.AvailableFrom,
                Price = product.Price,
                DiscountPrice = product.DiscountPrice,
                Sales = product.Sales
            };

            return View(productModel);
        }

        [HttpPost]
        public IActionResult Delete(ProductListViewModel model)
        {
            if (!productService.Exists(model.Id))
            {
                return BadRequest();
            }

            productService.Delete(model.Id);

            return RedirectToAction(nameof(All));
        }
    }
}
