using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebProject.Contracts;
using WebProject.Data;
using WebProject.Data.Models;
using WebProject.Models.AdminViewModel;

namespace WebProject.Services
{
    public class AdminService : IAdminService
    {
        private readonly GameStoreDbContext context;

        List<Administrator> potentialAdmins = new List<Administrator>();

        public AdminService(GameStoreDbContext _context)
        {
            context = _context;
        }

        public void Create(string userId, string phoneNumber)
        {
            var admin = new Administrator()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            context.Administrators.Add(admin);
            context.SaveChanges();
        }

        public int GetAdminId(string userId)
        {
            var adminId = context.Administrators.FirstOrDefault(a => a.UserId == userId).Id;

            return adminId;
        }

        public bool IsAdmin(string userId)
        {
            return context.Administrators.Any(a => a.UserId == userId);
        }

        public bool UserWithPhoneNumberExists(string phoneNumber)
        {
            return context.Administrators.Any(a => a.PhoneNumber == phoneNumber);
        }

        /*public async Task AddPotentialAdmin(string userId, PotentialAdminViewModel model)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            var admin = new Administrator()
            {
                Id = model.Id,
                PhoneNumber = model.PhoneNumber,
            };

            potentialAdmins.Add(admin);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Administrator>> potentialAdminsList(string userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            var admins = potentialAdmins.ToList();

            return admins.Select(a => new Administrator()
            {
                Id = a.Id,
                PhoneNumber = a.PhoneNumber,
            });
        }

        public async Task<Administrator> Approve(string userId)
        {
            var potentialAdmins = await potentialAdminsList(userId);

            var admin = potentialAdmins.FirstOrDefault(a => a.Id == userId);

            await context.Administrators.AddAsync(admin);
            await context.SaveChangesAsync();

            return admin;
        }*/

    }
}
