using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebProject.Data.Configuration;
using WebProject.Data.Models;

namespace WebProject.Data
{
    public class GameStoreDbContext : IdentityDbContext<User>
    {
        private bool SeedDb;

        public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options, bool seed = true )
            : base(options)
        {
            /*if(this.Database.IsRelational())
            {
                this.Database.Migrate();
            }
            else
            {
                this.Database.EnsureCreated();
            }

            this.SeedDb = seed;*/
        }

        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<GamingProduct> GamingProducts { get; set; } = null!;
        public DbSet<HealthProduct> HealthProducts { get; set; } = null!;
        public DbSet<Administrator> Administrators { get; set; } = null!;
        public DbSet<PotentialAdmin> PotentialAdmins { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AdminConfiguration());
            builder.ApplyConfiguration(new GameConfiguration());

            builder
                .Entity<UserGame>()
                .HasKey(x => new { x.UserId, x.GameId });

            builder
                .Entity<UserGamingProduct>()
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

            base.OnModelCreating(builder);
        }
    }
}