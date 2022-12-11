using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Contracts;
using WebProject.Data.Models;
using WebProject.Models.GamingProductViewModel;
using WebProject.Models.HealthProductViewModel;
using WebProject.Services;

namespace WebProject.Tests.UnitTests
{
    [TestFixture]
    public class HealthProductServiceTests : UnitTestsBase
    {
        private IHealthProductService healthProductService;

        [OneTimeSetUp]
        public void SetUp()
            => healthProductService = new HealthProductService(context);

        [Test]
        public void GetHealthProductId_ShouldReturnCorrectId()
        {
            var result = healthProductService.ProductDetailsById(this.HealthProduct.Id);

            Assert.That(this.HealthProduct.Id, Is.EqualTo(1));
        }

        [Test]
        public void HealthProductExistsInDb_ShouldReturnIfHealthProductExistsById()
        {
            var resultHealthProductId = healthProductService.Exists(this.HealthProduct.Id);

            Assert.IsTrue(resultHealthProductId);
        }

        [Test]
        public void HealthProductDetailsById_ShouldReturnCorrectHealthProductData()
        {
            var healthProductId = this.HealthProduct.Id;

            var result = healthProductService.ProductDetailsById(healthProductId);

            Assert.IsNotNull(result);

            var healthProductInDb = context.HealthProducts.Find(healthProductId);

            Assert.That(result.Id, Is.EqualTo(healthProductInDb.Id));
            Assert.That(result.Name, Is.EqualTo(healthProductInDb.Name));
        }

        [Test]
        public void Add_ShouldCreateHealthProduct()
        {
            var productsInDbBefore = context.HealthProducts.Count();

            var newProduct = new AddHealthProductModel()
            {
                Name = "Third TestName",
                Description = "Third TestDescription",
                Price = 10.0m,
                DiscountPrice = 7.0m,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQE71yLKH6QqyuwnY02KokINKViHp3R2wn2Ng&usqp=CAU",
                AvailableFrom = DateTime.UtcNow,
                Rating = 8.5m
            };

            var newProductId = healthProductService.AddHealthProduct(newProduct);

            /*var newGameId = gameService.AddGameToStoreAsync(newGame.GameName, newGame.Developer, newGame.Publisher, newGame.Description,
                newGame.Price, newGame.DiscountPrice, newGame.Genre, newGame.ImageUrl, newGame.Rating, newGame.ReleaseDate, newGame.Sales);*/

            var productsInDbAfter = context.HealthProducts.Count();
            Assert.That(productsInDbAfter, Is.EqualTo(productsInDbBefore + 1));

            var newProductInDb = context.HealthProducts.Find(2);
            Assert.That(newProductInDb.Name, Is.EqualTo(newProduct.Name));
        }

        [Test]
        public void Edit_ShouldEditHealthProductCorrectly()
        {
            var newProduct = new HealthProduct()
            {
                Name = "Third TestName",
                Description = "Third TestDescription",
                Price = 10.0m,
                DiscountPrice = 7.0m,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQE71yLKH6QqyuwnY02KokINKViHp3R2wn2Ng&usqp=CAU",
                AvailableFrom = DateTime.UtcNow,
                Rating = 8.5m
            };

            context.HealthProducts.Add(newProduct);
            context.SaveChanges();

            var changedName = "TestTest";

            healthProductService.Edit(newProduct.Id, changedName, newProduct.ImageUrl,
                newProduct.Description, newProduct.AvailableFrom, newProduct.Price, newProduct.DiscountPrice, newProduct.Rating);

            var newProductInDb = context.HealthProducts.Find(newProduct.Id);
            Assert.IsNotNull(newProductInDb);
            Assert.That(newProductInDb.Name, Is.EqualTo(changedName));
            Assert.That(newProductInDb.Id, Is.EqualTo(newProduct.Id));

            context.HealthProducts.Remove(newProduct);
        }

        [Test]
        public void Delete_ShouldDeleteHealthProductSuccessfully()
        {
            var newProduct = new HealthProduct()
            {
                Name = "Third TestName",
                Description = "Third TestDescription",
                Price = 10.0m,
                DiscountPrice = 7.0m,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQE71yLKH6QqyuwnY02KokINKViHp3R2wn2Ng&usqp=CAU",
                Rating = 8.80m,
                AvailableFrom = DateTime.UtcNow,
            };


            context.HealthProducts.Add(newProduct);
            context.SaveChanges();

            var productsCountBefore = context.HealthProducts.Count();

            healthProductService.Delete(newProduct.Id);

            var productsCountAfter = context.HealthProducts.Count();
            Assert.That(productsCountAfter, Is.EqualTo(productsCountBefore - 1));

            var newProductInDb = context.HealthProducts.Find(newProduct.Id);
            Assert.IsNull(newProductInDb);
        }

        [Test]
        public void HealthProductToCollection_ShouldAddHealthProductToMyCollection()
        {
            var userId = this.User.Id;
            var productId = this.HealthProduct.Id;

            var productInUserProductsBefore = this.User.UsersHealthProducts.Count();

            this.User.UsersHealthProducts.Add(new UserHealthProduct()
            {
                UserId = this.User.Id,
                User = this.User,
                HealthProduct = this.HealthProduct,
                HealthProductId = this.HealthProduct.Id
            });

            context.HealthProducts.Add(this.HealthProduct);


            healthProductService.AddToCollection(productId, userId);

            var productsInUserProductAfter = this.User.UsersHealthProducts.Count();

            Assert.That(productsInUserProductAfter, Is.EqualTo(productInUserProductsBefore + 1));

            var newProductInUserProduct = this.User.UsersHealthProducts.FirstOrDefault(x => x.HealthProductId == productId);

            Assert.That(newProductInUserProduct, Is.Not.Null);
            Assert.That(newProductInUserProduct.HealthProduct.Name, Is.EqualTo(this.HealthProduct.Name));
            Assert.That(newProductInUserProduct.HealthProduct.Id, Is.EqualTo(productId));
        }

        [Test]
        public void DeleteHealthProductFromCollection_ShouldDeleteHealthProductFromMyCollection()
        {
            var userId = this.User.Id;
            var productId = this.HealthProduct.Id;

            this.User.UsersHealthProducts.Add(new UserHealthProduct()
            {
                UserId = this.User.Id,
                User = this.User,
                HealthProduct = this.HealthProduct,
                HealthProductId = this.HealthProduct.Id
            });

            var userProduct = this.User.UsersHealthProducts.FirstOrDefault(x => x.HealthProductId == productId);

            var productsInUserProductBefore = this.User.UsersHealthProducts.Count();

            this.User.UsersHealthProducts.Remove(userProduct);

            healthProductService.RemoveFromCollection(productId, userId);

            var productsInUserProductAfter = this.User.UsersHealthProducts.Count();

            Assert.That(productsInUserProductAfter, Is.EqualTo(productsInUserProductBefore - 1));

            var removedProductFromUserProducts = this.User.UsersHealthProducts.FirstOrDefault(x => x.HealthProductId == productId);

            Assert.IsNull(removedProductFromUserProducts);
        }

        [Test]
        public void AllHealthProductsShowcase_ShouldShowAllHealthProductsCorrectly()
        {
            var products = healthProductService.ShowAllProducts();
            Assert.IsNotNull(products);
        }

        [Test]
        public void MyCartAllHealthProductsShowcase_ShouldShowAllUserHealthProductsCorrectly()
        {
            this.User.UsersHealthProducts.Add(new UserHealthProduct()
            {
                UserId = this.User.Id,
                User = this.User,
                HealthProduct = this.HealthProduct,
                HealthProductId = this.HealthProduct.Id
            });

            var products = healthProductService.ShowMyProducts(this.User.Id);
            Assert.IsNotNull(products);
        }
    }
}
