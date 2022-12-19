using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebProject.Data.Models;

namespace WebProject.Data.Configuration
{
    internal class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasData(SeedGames());
        }

        private List<Game> SeedGames()
        {
            var games = new List<Game>()
            {
                new Game()
                {
                    Id = 51,
                    GameName = "Marvel's Spider-Man Remastered",
                    Developer = "Insomniac Games, Nixxes Software",
                    Publisher = "PlayStation PC LLC",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQkNdE1mKG_ZhqEjCaN2TpX_oDTcirJSooc3Q&usqp=CAU",
                    Sales =  570500,
                    Price = 120.0M,
                    DiscountPrice = 80.0M,
                    Description = "In Marvel’s Spider-Man Remastered, the worlds of Peter Parker and Spider-Man collide in an original, action-packed story. Play as an experienced Peter Parker, fighting big crime and iconic villains in Marvel’s New York. Web-swing through vibrant neighborhoods and defeat villains with epic takedowns.",
                    Genre = "Action-Adventure",
                    Rating = 9.50m,
                    ReleaseDate = DateTime.UtcNow,
                },

                new Game()
                {
                    Id = 52,
                    GameName = "FIFA 23",
                    Developer = "EA Canada",
                    Publisher = "Electronic Arts",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSIItQ_gWsM03vMqaQ0QhA5QRXwOl17TK_5HQ&usqp=CAU",
                    Sales =  980500,
                    Price = 139.0M,
                    DiscountPrice = 55.99M,
                    Description = "Experience the excitement of the biggest tournament in football with EA SPORTS™ FIFA 23 and the men’s FIFA World Cup™ update, available on November 9 at no additional cost*.",
                    Genre = "Simulation",
                    Rating = 8.50m,
                    ReleaseDate = DateTime.UtcNow,
                },

                 new Game()
                {
                    Id = 53,
                    GameName = "Saints Row",
                    Developer = "Deep Silver Volition",
                    Publisher = "Deep Silver",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRcEsRkuklD9EGzsDVC_KF1UiQNcVQ3rWt7ww&usqp=CAU",
                    Sales =  470800,
                    Price = 115.0M,
                    DiscountPrice = 67.99M,
                    Description = "Welcome to Santo Ileso, a vibrant fictional city in the American Southwest. In a world rife with crime, a group of young friends embark on their own criminal venture, as they rise to the top in their bid to become Self Made.",
                    Genre = "Action-Adventure, Shooter, Open World",
                    Rating = 8.00m,
                    ReleaseDate = DateTime.UtcNow,
                },
            };

            return games;
        }
    }
}
