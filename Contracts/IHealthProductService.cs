using WebProject.Models.Enumerations;
using WebProject.Models.HealthProductViewModel;

namespace WebProject.Contracts
{
    public interface IHealthProductService
    {
        Task<HealthQueryModel> ShowAllProducts(
            string? searchTerm,
            HealthSorting sorting = HealthSorting.Newest,
            int currentPage = 1,
            int productsPerPage = 1);

        Task AddHealthProduct(AddHealthProductModel model);

        Task AddToCollection(int productId, string userId);

        Task RemoveFromCollection(int productId, string userId);

        Task<IEnumerable<HealthProductListViewModel>> ShowMyProducts(string userId);


        bool Exists(int productId);
        HealthProductListViewModel ProductDetailsById(int productId);

        void Edit(int productId, string name, string imageUrl, string description, DateTime availableFrom, decimal price,
            decimal discountPrice, decimal rating);

        void Delete(int productId);

    }
}
