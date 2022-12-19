using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebProject.Data.Models;

namespace WebProject.Data.Configuration
{
    internal class PotentialAdminConfiguration : IEntityTypeConfiguration<PotentialAdmin>
    {
        public void Configure(EntityTypeBuilder<PotentialAdmin> builder)
        {
            builder.HasData(new PotentialAdmin()
            {
                Id = 99,
                PhoneNumber = "+359777777778",
                UserId = "qwe77756-2745-3754-n8h3-f888h4253082"
            });
        }


    }
}
