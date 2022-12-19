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

        public async Task AddPotentialAdmin(string userId, PotentialAdminViewModel model)
        {
            // could probably remove (string userId) and use model.UserId!
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if(!context.PotentialAdmins.Any(a => a.UserId == model.UserId))
            {
                var admin = new PotentialAdmin()
                {
                    Id = model.Id,
                    PhoneNumber = model.PhoneNumber,
                    UserId = model.UserId
                };

                context.PotentialAdmins.Add(admin);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PotentialAdmin>> potentialAdminsList()
        {
            return context.PotentialAdmins.Select(a => new PotentialAdmin()
            {
                Id = a.Id,
                PhoneNumber = a.PhoneNumber,
                UserId = a.UserId
            })
                .ToList();
        }

        public async Task Approve(int adminId)
        {
            //var potentialAdmin = potentialAdmins.FirstOrDefault(a => a.Id == adminId);
            var potentialAdmin = context.PotentialAdmins.Find(adminId);

            var newAdmin = new Administrator()
            {
                UserId = potentialAdmin.UserId,
                PhoneNumber = potentialAdmin.PhoneNumber
            };

            await context.Administrators.AddAsync(newAdmin);
            context.PotentialAdmins.Remove(potentialAdmin);


            // await context.SaveChangesAsync() DID NOT WORK 
            context.SaveChanges();
        }

    }
}
