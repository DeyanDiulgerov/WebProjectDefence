using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebProject.Data.Models;

namespace WebProject.Data
{
    public class GameStoreDbContext : IdentityDbContext<User>
    {
        public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<HealthProduct> HealthProducts { get; set; }
        public DbSet<Administrator> Administrators { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<UserGame>()
                .HasKey(x => new { x.UserId, x.GameId });

            builder
                .Entity<UserProduct>()
                .HasKey(x => new { x.UserId, x.ProductId });

            builder
               .Entity<UserHealthProduct>()
               .HasKey(x => new { x.UserId, x.HealthProductId });

            builder
                .Entity<User>()
                .Property(x => x.UserName)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Entity<User>()
                .Property(x => x.Email)
                .HasMaxLength(60)
                .IsRequired();

            /*builder
                .Entity<Genre>()
                .HasData(new Genre()
                {
                    Id = 1,
                    Name = "Sandbox"
                },
                new Genre()
                {
                    Id = 2,
                    Name = "Real-time strategy"
                },
                new Genre()
                {
                    Id = 3,
                    Name = "Shooter"
                },
                new Genre()
                {
                    Id = 4,
                    Name = "MOBA"
                },
                new Genre()
                {
                    Id = 5,
                    Name = "Role-playing"
                },
                new Genre()
                {
                    Id = 6,
                    Name = "Simulation and sports"
                },
                new Genre()
                {
                    Id = 7,
                    Name = "Action-adventure"
                },
                new Genre()
                {
                    Id = 8,
                    Name = "Survival and horror"
                },
                new Genre()
                {
                    Id = 9,
                    Name = "Platformer"
                });*/

            base.OnModelCreating(builder);
        }
    }
}