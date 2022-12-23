using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Contracts;
using WebProject.Data.Models;
using WebProject.Models.GameViewModel;
using WebProject.Models.GamingProductViewModel;
using WebProject.Services;

namespace WebProject.Tests.UnitTests
{
    [TestFixture]
    public class GamingProductServiceTests : UnitTestsBase
    {
        private IGamingProductService productService;

        [OneTimeSetUp]
        public void SetUp()
            => productService = new GamingProductService(context);

        [Test]
        public void GetProductId_ShouldReturnCorrectId()
        {
            var result = productService.ProductDetailsById(this.Product.Id);

            Assert.That(this.Product.Id, Is.EqualTo(1));
        }

        [Test]
        public void ProductExistsInDb_ShouldReturnIfProductExistsById()
        {
            var resultProductId = productService.Exists(this.Product.Id);

            Assert.IsTrue(resultProductId);
        }

        [Test]
        public void ProductDetailsById_ShouldReturnCorrectProductData()
        {
            var productId = this.Product.Id;

            var result = productService.ProductDetailsById(productId);

            Assert.IsNotNull(result);

            var productInDb = context.GamingProducts.Find(productId);

            Assert.That(result.Id, Is.EqualTo(productInDb.Id));
            Assert.That(result.Name, Is.EqualTo(productInDb.Name));
        }

        [Test]
        public void Add_ShouldCreateProduct()
        {
            var productsInDbBefore = context.GamingProducts.Count();

            var newProduct = new AddProductViewModel()
            {
                Name = "Third TestName",
                Company = "Third TestCompany",
                Description = "Third TestDescription",
                Price = 10.0m,
                DiscountPrice = 7.0m,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQE71yLKH6QqyuwnY02KokINKViHp3R2wn2Ng&usqp=CAU",
                Sales = 25,
                AvailableFrom = DateTime.UtcNow,
            };

            var newProductId = productService.AddProductForSaleAsync(newProduct);

            /*var newGameId = gameService.AddGameToStoreAsync(newGame.GameName, newGame.Developer, newGame.Publisher, newGame.Description,
                newGame.Price, newGame.DiscountPrice, newGame.Genre, newGame.ImageUrl, newGame.Rating, newGame.ReleaseDate, newGame.Sales);*/

            var productsInDbAfter = context.GamingProducts.Count();
            Assert.That(productsInDbAfter, Is.EqualTo(productsInDbBefore + 1));

            var newProductInDb = context.GamingProducts.Find(2);
            Assert.That(newProductInDb.Name, Is.EqualTo(newProduct.Name));
        }

        [Test]
        public void Edit_ShouldEditProductCorrectly()
        {
            var newProduct = new GamingProduct()
            {
                Name = "Third TestName",
                Company = "Third TestCompany",
                Description = "Third TestDescription",
                Price = 10.0m,
                DiscountPrice = 7.0m,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQE71yLKH6QqyuwnY02KokINKViHp3R2wn2Ng&usqp=CAU",
                Sales = 25,
                AvailableFrom = DateTime.UtcNow,
            };

            context.GamingProducts.Add(newProduct);
            context.SaveChanges();

            var changedName = "TestTest";

            productService.Edit(newProduct.Id, changedName, newProduct.Company, newProduct.ImageUrl,
                newProduct.Description, newProduct.AvailableFrom, newProduct.Sales, newProduct.Price, newProduct.DiscountPrice);

            var newProductInDb = context.GamingProducts.Find(newProduct.Id);
            Assert.IsNotNull(newProductInDb);
            Assert.That(newProductInDb.Name, Is.EqualTo(changedName));
            Assert.That(newProductInDb.Id, Is.EqualTo(newProduct.Id));

            context.GamingProducts.Remove(newProduct);
        }

        [Test]
        public void Delete_ShouldDeleteProductSuccessfully()
        {
            var newProduct = new GamingProduct()
            {
                Name = "Third TestName",
                Company = "Third TestCompany",
                Description = "Third TestDescription",
                Price = 10.0m,
                DiscountPrice = 7.0m,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQE71yLKH6QqyuwnY02KokINKViHp3R2wn2Ng&usqp=CAU",
                Sales = 25,
                AvailableFrom = DateTime.UtcNow,
            };


            context.GamingProducts.Add(newProduct);
            context.SaveChanges();

            var productsCountBefore = context.GamingProducts.Count();

            productService.Delete(newProduct.Id);

            var productsCountAfter = context.GamingProducts.Count();
            Assert.That(productsCountAfter, Is.EqualTo(productsCountBefore - 1));

            var newProductInDb = context.GamingProducts.Find(newProduct.Id);
            Assert.IsNull(newProductInDb);
        }

        [Test]
        public void ProductToCollection_ShouldAddProductToMyCollection()
        {
            var userId = this.User.Id;
            var productId = this.Product.Id;

            var productInUserProductsBefore = this.User.UserGamingProducts.Count();

            this.User.UserGamingProducts.Add(new UserGamingProduct()
            {
                UserId = this.User.Id,
                User = this.User,
                Product = this.Product,
                ProductId = this.Product.Id
            });

            context.GamingProducts.Add(this.Product);


            productService.AddProductToMyCollection(productId, userId);

            var productsInUserProductAfter = this.User.UserGamingProducts.Count();

            Assert.That(productsInUserProductAfter, Is.EqualTo(productInUserProductsBefore + 1));

            var newProductInUserProduct = this.User.UserGamingProducts.FirstOrDefault(x => x.ProductId == productId);

            Assert.That(newProductInUserProduct, Is.Not.Null);
            Assert.That(newProductInUserProduct.Product.Name, Is.EqualTo(this.Product.Name));
            Assert.That(newProductInUserProduct.Product.Id, Is.EqualTo(productId));
        }

        [Test]
        public void DeleteProductFromCollection_ShouldDeleteProductFromMyCollection()
        {
            var userId = this.User.Id;
            var productId = this.Product.Id;

            this.User.UserGamingProducts.Add(new UserGamingProduct()
            {
                UserId = this.User.Id,
                User = this.User,
                Product = this.Product,
                ProductId = this.Product.Id
            });

            var userProduct = this.User.UserGamingProducts.FirstOrDefault(x => x.ProductId == productId);

            var productsInUserProductBefore = this.User.UserGamingProducts.Count();

            this.User.UserGamingProducts.Remove(userProduct);

            productService.RemoveFromMyCollection(productId, userId);

            var productsInUserProductAfter = this.User.UserGamingProducts.Count();

            Assert.That(productsInUserProductAfter, Is.EqualTo(productsInUserProductBefore - 1));

            var removedProductFromUserProducts = this.User.UserGamingProducts.FirstOrDefault(x => x.ProductId == productId);

            Assert.IsNull(removedProductFromUserProducts);
        }

        [Test]
        public void AllProductsShowcase_ShouldShowAllProductsCorrectly()
        {
            string searchTerm = null;

            var products = productService.AllProductsListAsync(searchTerm);
            Assert.IsNotNull(products);
        }

        [Test]
        public void MyCartAllProductsShowcase_ShouldShowAllUserProductsCorrectly()
        {
            this.User.UserGamingProducts.Add(new UserGamingProduct()
            {
                UserId = this.User.Id,
                User = this.User,
                Product = this.Product,
                ProductId = this.Product.Id
            });

            var products = productService.MyProductsAsync(this.User.Id);
            Assert.IsNotNull(products);
        }
    }
}
