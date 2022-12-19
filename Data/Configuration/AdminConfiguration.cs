using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebProject.Data.Models;

namespace WebProject.Data.Configuration
{
    internal class AdminConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.HasData(new Administrator()
            {
                Id = 98,
                PhoneNumber = "+359777777777",
                UserId = "dea12856-c198-4129-b3f3-b893d8395082"
            });
        }        
    }
}
