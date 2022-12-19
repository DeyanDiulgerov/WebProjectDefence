using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebProject.Data.Models;

namespace WebProject.Data.Configuration
{
    internal class GamingProductsConfiguration : IEntityTypeConfiguration<GamingProduct>
    {
        public void Configure(EntityTypeBuilder<GamingProduct> builder)
        {
            builder.HasData(SeedGamingProducts());
        }

        private List<GamingProduct> SeedGamingProducts()
        {
            var gamingProducts = new List<GamingProduct>()
            {
                new GamingProduct()
                {
                    Id = 15,
                    Name = "Huzaro Force 2.5",
                    Company = "Huzaro Force",
                    ImageUrl = "https://s13emagst.akamaized.net/products/46245/46244850/images/res_376bec9a17bddc707b0d6ecfc12ef53a.jpg?width=450&height=450&hash=25F4624F460E1BCE5DB13E19A5DB62FD",
                    Sales =  24,
                    Price = 299.0M,
                    DiscountPrice = 225.0M,
                    Description = "Gaming chair Huzaro Force 2.5, Mesh, Black / Carbon RGB.",
                    AvailableFrom = DateTime.UtcNow,
                },

                new GamingProduct()
                {
                    Id = 16,
                    Name = "G-Fuel Black Ice",
                    Company = "G-Fuel",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTdKI0RNcIzMw2gNUF7YWA_0xT13xb4LktRNQ&usqp=CAU",
                    Sales =  80,
                    Price = 40.0M,
                    DiscountPrice = 40.0M,
                    Description = "Blackberry Pear Vanilla",
                    AvailableFrom = DateTime.UtcNow,
                },
            };

            return gamingProducts;
        }
    }
}
