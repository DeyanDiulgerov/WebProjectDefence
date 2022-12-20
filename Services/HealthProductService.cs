﻿using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WebProject.Contracts;
using WebProject.Data;
using WebProject.Data.Models;
using WebProject.Models.Enumerations;
using WebProject.Models.HealthProductViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebProject.Services
{
    public class HealthProductService : IHealthProductService
    {
        private readonly GameStoreDbContext context;

        public HealthProductService
            (GameStoreDbContext _context)
        {
            context = _context;
        }

        public async Task AddHealthProduct(AddHealthProductModel model)
        {
            var product = new HealthProduct()
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                AvailableFrom = model.AvailableFrom,
                Price = model.Price,
                DiscountPrice = model.DiscountPrice,
                Rating = model.Rating
            };

            await context.HealthProducts.AddAsync(product);
            await context.SaveChangesAsync();
        }
        public async Task<HealthQueryModel> ShowAllProducts(
            string? searchTerm,
            HealthSorting sorting = HealthSorting.Newest,
            int currentPage = 1,
            int productsPerPage = 1)
        {
            var result = new HealthQueryModel();
            var products = context.HealthProducts.AsQueryable();

            if(string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm}%";

                products = products
                    .Where(p => EF.Functions.Like(p.Name.ToLower(), searchTerm) ||
                    EF.Functions.Like(p.Description.ToLower(), searchTerm));
            }

            products = sorting switch
            {
                HealthSorting.Price => products.OrderBy(p => p.Price),
                HealthSorting.DiscountPrice => products.OrderBy(p => p.DiscountPrice),
                HealthSorting.Rating => products.OrderByDescending(p => p.Rating),
                _ => products.OrderByDescending(p => p.Id)
            };

            result.HealthProducts = await products
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .Select(p => new HealthProductListViewModel()
                {
                    Name = p.Name,
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    AvailableFrom = p.AvailableFrom,
                    Price = p.Price,
                    DiscountPrice = p.DiscountPrice,
                    Rating = p.Rating
                })
                .ToListAsync();

            result.TotalHealthProductsCount = await products.CountAsync();

            return result;
        }

        public async Task AddToCollection(int productId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersHealthProducts)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("We coudnt find such user");
            }

            var product = await context.HealthProducts.FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                throw new ArgumentException("We couldnt find such product");
            }

            if (!user.UsersHealthProducts.Any(p => p.HealthProductId == productId))
            {
                user.UsersHealthProducts.Add(new UserHealthProduct()
                {
                    User = user,
                    UserId = user.Id,
                    HealthProduct = product,
                    HealthProductId = product.Id
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveFromCollection(int productId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersHealthProducts)
                .ThenInclude(up => up.HealthProduct)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("We coudnt find such user");
            }

            var product = user.UsersHealthProducts.FirstOrDefault(p => p.HealthProductId == productId);

            if (product != null)
            {
                user.UsersHealthProducts.Remove(product);

                await context.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<HealthProductListViewModel>> ShowMyProducts(string userId)
        {
            var user = await context.Users
               .Where(u => u.Id == userId)
               .Include(u => u.UsersHealthProducts)
               .ThenInclude(up => up.HealthProduct)
               .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("We coudnt find such user");
            }

            return user.UsersHealthProducts
                .Select(p => new HealthProductListViewModel() 
                {
                    Name = p.HealthProduct.Name,
                    Id = p.HealthProduct.Id,
                    ImageUrl = p.HealthProduct.ImageUrl,
                    Description = p.HealthProduct.Description,
                    AvailableFrom = p.HealthProduct.AvailableFrom,
                    Price = p.HealthProduct.Price,
                    DiscountPrice = p.HealthProduct.DiscountPrice,
                    Rating = p.HealthProduct.Rating
                });
        }

        public bool Exists(int productId)
        {
            return context.HealthProducts.Any(p => p.Id == productId);
        }

        public HealthProductListViewModel ProductDetailsById(int productId)
        {
            var product = context.HealthProducts
                .Where(p => p.Id == productId)
                .Select(p => new HealthProductListViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    Price = p.Price,
                    DiscountPrice = p.DiscountPrice,
                    AvailableFrom = p.AvailableFrom,
                    Rating = p.Rating
                }).FirstOrDefault();

            return product;
        }

        public void Edit(int productId, string name, string imageUrl, string description, DateTime availableFrom,
            decimal price, decimal discountPrice, decimal rating)
        {
            var product = context.HealthProducts.Find(productId);

            product.Name = name;
            product.ImageUrl = imageUrl;
            product.Description = description;
            product.AvailableFrom = availableFrom;
            product.Price = price;
            product.DiscountPrice = discountPrice;
            product.Rating = rating;

            context.SaveChanges();
        }

        public void Delete(int productId)
        {
            var product = context.HealthProducts.Find(productId);

            context.HealthProducts.Remove(product);
            context.SaveChanges();
        }
    }
}
