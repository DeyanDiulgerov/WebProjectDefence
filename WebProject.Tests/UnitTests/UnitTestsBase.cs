using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Data;
using WebProject.Data.Models;
using WebProject.Tests.Mocks;

namespace WebProject.Tests.UnitTests
{
    public class UnitTestsBase
    {
        private const decimal TestPrice = 10.0M;
        private const decimal TestDiscountPrice = 8.0M;
        private const decimal TestRating = 9.9M;
        private int? TestSales = 100;
        private DateTime TestReleaseDate = DateTime.Now;


        protected GameStoreDbContext context;

        [OneTimeSetUp]
        public void SetUpBase()
        {
            this.context = DatabaseMock.Instance;
            this.SeedDatabase();
        }

        public Game Game { get; private set; }
        public Product Product { get; private set; }
        public HealthProduct HealthProduct { get; private set; }
        public Administrator Administrator { get; private set; }


        private void SeedDatabase()
        {
            this.Game = new Game()
            {
                Developer = "TestDeveloper",
                Publisher = "TestPublisher",
                Description = "TestDescription",
                GameName = "TestName",
                Price = TestPrice,
                DiscountPrice = TestDiscountPrice,
                Genre = "TestGenre",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQE71yLKH6QqyuwnY02KokINKViHp3R2wn2Ng&usqp=CAU",
                Rating = TestRating,
                ReleaseDate = TestReleaseDate,
                Sales = TestSales
            };
            context.Games.Add(this.Game);

            var secondGame = new Game()
            {
                Developer = "Second TestDeveloper",
                Publisher = "Second TestPublisher",
                Description = "Second TestDescription",
                GameName = "Second TestName",
                Price = TestPrice,
                DiscountPrice = TestDiscountPrice,
                Genre = "Second TestGenre",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQE71yLKH6QqyuwnY02KokINKViHp3R2wn2Ng&usqp=CAU",
                Rating = TestRating,
                ReleaseDate = TestReleaseDate,
                Sales = TestSales
            };
            context.Games.Add(secondGame);

            this.Product = new Product()
            {
                Id = 1,
                Description = "TestDescription",
                Name = "TestName",
                Price = TestPrice,
                DiscountPrice = TestDiscountPrice,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQE71yLKH6QqyuwnY02KokINKViHp3R2wn2Ng&usqp=CAU",
                AvailableFrom = TestReleaseDate,
                Sales = TestSales,
                Company = "TestCompany"
            };
            context.Products.Add(this.Product);

            this.HealthProduct = new HealthProduct()
            {
                Id = 1,
                Description = "TestDescription",
                Name = "TestName",
                Price = TestPrice,
                DiscountPrice = TestDiscountPrice,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQE71yLKH6QqyuwnY02KokINKViHp3R2wn2Ng&usqp=CAU",
                Rating = TestRating
            };
            context.HealthProducts.Add(this.HealthProduct);

            this.Administrator = new Administrator()
            {
                Id = 1,
                PhoneNumber = "0877111111",
                User = new User
                {
                    Id = "TestAdminUserId",
                    Email = "Test@test.bg",
                    UserName = "Test"
                }            
            };
            context.Administrators.Add(this.Administrator);
            context.SaveChanges();
        }

        [OneTimeTearDown]
        public void TearDownBase()
            => this.context.Dispose();
    }
}
