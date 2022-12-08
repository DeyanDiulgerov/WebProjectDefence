using WebProject.Data.Models;
using WebProject.Models.AdminViewModel;

namespace WebProject.Contracts
{
    public interface IAdminService
    {
        bool IsAdmin(string userId);

        bool UserWithPhoneNumberExists(string phoneNumber);

        void Create(string userId, string phoneNumber);


        /*Task<Administrator> Approve(string userId);

        Task AddPotentialAdmin(string userId, PotentialAdminViewModel model);

        Task<IEnumerable<Administrator>> potentialAdminsList(string userId);*/
    }
}
