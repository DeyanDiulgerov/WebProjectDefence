namespace WebProject.Contracts
{
    public interface IAdminService
    {
        bool IsAdmin(string userId);

        bool UserWithPhoneNumberExists(string phoneNumber);

        void Create(string userId, string phoneNumber);
    }
}
