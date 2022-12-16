using WebProject.Data.Models;
using WebProject.Models.AdminViewModel;

namespace WebProject.Contracts
{
    public interface IAdminService
    {
        bool IsAdmin(string userId);

        bool UserWithPhoneNumberExists(string phoneNumber);

        void Create(string userId, string phoneNumber);

        int GetAdminId(string userId);


        Task Approve(int adminId);

        Task AddPotentialAdmin(string userId, PotentialAdminViewModel model);

        Task<IEnumerable<PotentialAdmin>> potentialAdminsList();
    }
}
