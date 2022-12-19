using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebProject.Data.Models;

namespace WebProject.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(SeedUsers());
        }

        private List<User> SeedUsers()
        {
            var users = new List<User>();
            var hasher = new PasswordHasher<User>();

            var adminUser = new User()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "SeededAdminUser",
                NormalizedUserName = "SEEDEDADMINUSER",
                Email = "admin@email.com",
                NormalizedEmail = "ADMIN@EMAIL.COM"
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "admin123");

            users.Add(adminUser);

            var user = new User()
            {
                Id = "eac44456-3215-3124-n5n3-b893h4253082",
                UserName = "SeededUser",
                NormalizedUserName = "SEEDEDUSER",
                Email = "guest@email.com",
                NormalizedEmail = "GUEST@EMAIL.COM"
            };

            user.PasswordHash = hasher.HashPassword(user, "guest123");

            users.Add(user);

            var potentialAdmin = new User()
            {
                Id = "qwe77756-2745-3754-n8h3-f888h4253082",
                UserName = "PotentialUser",
                NormalizedUserName = "POTENTIALUSER",
                Email = "potential@email.com",
                NormalizedEmail = "POTENTIAL@EMAIL.COM"
            };

            potentialAdmin.PasswordHash = hasher.HashPassword(potentialAdmin, "potential123");

            users.Add(potentialAdmin);

            return users;
        }
    }
}
