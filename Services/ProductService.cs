using Microsoft.EntityFrameworkCore;
using WebProject.Contracts;
using WebProject.Data;
using WebProject.Data.Models;
using WebProject.Models;

namespace WebProject.Services
{
    public class ProductService : IProductService
    {
        private readonly GameStoreDbContext context;

        public ProductService
            (GameStoreDbContext _context)
        {
            context = _context;
        }

        public async Task AddProductForSaleAsync(AddProductViewModel model)
        {
            var product = new Product()
            {
                Name = model.Name,
                Company = model.Company,
                AvailableFrom = model.AvailableFrom,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                Price = model.Price,
                DiscountPrice = model.DiscountPrice,
                Sales = model.Sales
            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
        }

        public async Task AddProductToMyCollection(int productId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UserProducts)
                .FirstOrDefaultAsync();            

            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == productId);

            if (user == null)
            {
                throw new ArgumentException("We couldnt find a user with such information");
            }

            if (product == null)
            {
                throw new ArgumentException("We couldnt find a product with such information");
            }

            if(!user.UserProducts.Any(p => p.ProductId == productId))
            {
                user.UserProducts.Add(new UserProduct()
                {
                    UserId = user.Id,
                    User = user,
                    ProductId = product.Id,
                    Product = product
                });

                await context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<ProductListViewModel>> AllProductsListAsync()
        {
            var products = await context.Products
                .ToListAsync();

            return products
                .Select(p => new ProductListViewModel()
                {
                    Name = p.Name,
                    Id = p.Id,
                    Company = p.Company,
                    AvailableFrom = p.AvailableFrom,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    Price = p.Price,
                    DiscountPrice = p.DiscountPrice,
                    Sales = p.Sales
                });
        }

        public async Task<IEnumerable<ProductListViewModel>> MyProductsAsync(string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UserProducts)
                .ThenInclude(up => up.Product)
                .FirstOrDefaultAsync();

            if(user == null)
            {
                throw new ArgumentException("Invalid user information");
            }

            return user.UserProducts
                .Select(p => new ProductListViewModel()
                {
                    Name = p.Product.Name,
                    Company = p.Product.Company,
                    AvailableFrom = p.Product.AvailableFrom,
                    ImageUrl = p.Product.ImageUrl,
                    Id = p.Product.Id,
                    Description = p.Product.Description,
                    Price = p.Product.Price,
                    DiscountPrice = p.Product.DiscountPrice,
                    Sales = p.Product.Sales
                });
        }

        public async Task RemoveFromMyCollection(int productId, string userId)
        {
            var user = await context.Users
               .Where(u => u.Id == userId)
               .Include(u => u.UserProducts)
               .ThenInclude(up => up.Product)
               .FirstOrDefaultAsync();


            if (user == null)
            {
                throw new ArgumentException("Invalid user information");
            }

            var product = user.UserProducts.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                user.UserProducts.Remove(product);

                await context.SaveChangesAsync();
            }
        }
    }
}
