using Microsoft.EntityFrameworkCore;
using WebProject.Contracts;
using WebProject.Data;
using WebProject.Data.Models;
using WebProject.Models.GamingProductViewModel;

namespace WebProject.Services
{
    public class GamingProductService : IGamingProductService
    {
        private readonly GameStoreDbContext context;

        public GamingProductService
            (GameStoreDbContext _context)
        {
            context = _context;
        }

        public async Task AddProductForSaleAsync(AddProductViewModel model)
        {
            var product = new GamingProduct()
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

            await context.GamingProducts.AddAsync(product);
            await context.SaveChangesAsync();
        }


        public async Task<IEnumerable<ProductListViewModel>> AllProductsListAsync()
        {
            var products = await context.GamingProducts
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
                .Include(u => u.UserGamingProducts)
                .ThenInclude(up => up.Product)
                .FirstOrDefaultAsync();

            if(user == null)
            {
                throw new ArgumentException("Invalid user information");
            }

            return user.UserGamingProducts
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
        public async Task AddProductToMyCollection(int productId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UserGamingProducts)
                .FirstOrDefaultAsync();            

            var product = await context.GamingProducts.FirstOrDefaultAsync(p => p.Id == productId);

            if (user == null)
            {
                throw new ArgumentException("We couldnt find a user with such information");
            }

            if (product == null)
            {
                throw new ArgumentException("We couldnt find a product with such information");
            }

            if(!user.UserGamingProducts.Any(p => p.ProductId == productId))
            {
                user.UserGamingProducts.Add(new UserGamingProduct()
                {
                    UserId = user.Id,
                    User = user,
                    ProductId = product.Id,
                    Product = product
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveFromMyCollection(int productId, string userId)
        {
            var user = await context.Users
               .Where(u => u.Id == userId)
               .Include(u => u.UserGamingProducts)
               .ThenInclude(up => up.Product)
               .FirstOrDefaultAsync();


            if (user == null)
            {
                throw new ArgumentException("Invalid user information");
            }

            var product = user.UserGamingProducts.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                user.UserGamingProducts.Remove(product);

                await context.SaveChangesAsync();
            }
        }

        public bool Exists(int productId)
        {
            return context.GamingProducts.Any(p => p.Id == productId);
        }

        public ProductListViewModel ProductDetailsById(int productId)
        {
            var product = context.GamingProducts
                .Where(p => p.Id == productId)
                .Select(p => new ProductListViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Company = p.Company,
                    Description = p.Description,
                    AvailableFrom = p.AvailableFrom,
                    Price = p.Price,
                    DiscountPrice = p.DiscountPrice,
                    Sales = p.Sales,
                    ImageUrl = p.ImageUrl,
                }).FirstOrDefault();

            return product;
        }

        public void Edit(int productId, string name, string company, string imageUrl, string description,
            DateTime availableFrom, int? sales, decimal price, decimal discountPrice)
        {
            var product = context.GamingProducts.Find(productId);

            product.Name = name;
            product.Company = company;
            product.ImageUrl = imageUrl;
            product.Description = description;
            product.AvailableFrom = availableFrom;
            product.Sales = sales;
            product.Price = price;
            product.DiscountPrice = discountPrice;

            context.SaveChanges();
        }

        public void Delete(int productId)
        {
            var product = context.GamingProducts.Find(productId);

            context.GamingProducts.Remove(product);
            context.SaveChanges();
        }
    }
}
