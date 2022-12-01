using Microsoft.EntityFrameworkCore;
using WebProject.Contracts;
using WebProject.Data;
using WebProject.Data.Models;
using WebProject.Models.HealthProductViewModel;

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
        public async Task<IEnumerable<HealthProductListViewModel>> ShowAllProducts()
        {
            var products = await context.HealthProducts
                .ToListAsync();

            return products
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
                });
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
    }
}
