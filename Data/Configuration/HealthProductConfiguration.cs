using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebProject.Data.Models;

namespace WebProject.Data.Configuration
{
    internal class HealthProductConfiguration : IEntityTypeConfiguration<HealthProduct>
    {
        public void Configure(EntityTypeBuilder<HealthProduct> builder)
        {
            builder.HasData(SeedHealthProducts());
        }

        private List<HealthProduct> SeedHealthProducts()
        {
            var healthProducts = new List<HealthProduct>()
            {
                new HealthProduct()
                {
                    Id = 15,
                    Name = "Yoga Mat",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTtN_yNN5YYtDfL0WOpOjjC6VbdWk-yWKQ7gg&usqp=CAU",
                    Price = 20.0M,
                    DiscountPrice = 20.0M,
                    Description = "Yoga Mat Purple",
                    AvailableFrom = DateTime.UtcNow,
                    Rating = 10.0M,
                },

                new HealthProduct()
                {
                    Id = 16,
                    Name = "Waist Belt",
                    ImageUrl = "https://m.media-amazon.com/images/W/WEBP_402378-T1/images/I/716jwuY6oJL._AC_SS130_.jpg",
                    Price = 24.0M,
                    DiscountPrice = 24.0M,
                    Description = "Grin Health Lumbar Support/Lower Back",
                    AvailableFrom = DateTime.UtcNow,
                    Rating = 10.0M,
                },
            };

            return healthProducts;
        }
    }
}
