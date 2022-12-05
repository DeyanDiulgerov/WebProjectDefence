using WebProject.Contracts;
using WebProject.Data;
using WebProject.Data.Models;

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

        public bool IsAdmin(string userId)
        {
            return context.Administrators.Any(a => a.UserId == userId);
        }

        public bool UserWithPhoneNumberExists(string phoneNumber)
        {
            return context.Administrators.Any(a => a.PhoneNumber == phoneNumber);
        }
    }
}
