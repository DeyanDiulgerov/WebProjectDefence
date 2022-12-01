using WebProject.Models.HealthProductViewModel;

namespace WebProject.Contracts
{
    public interface IHealthProductService
    {
        Task<IEnumerable<HealthProductListViewModel>> ShowAllProducts();

        Task AddHealthProduct(AddHealthProductModel model);

        Task AddToCollection(int productId, string userId);

        Task RemoveFromCollection(int productId, string userId);

        Task<IEnumerable<HealthProductListViewModel>> ShowMyProducts(string userId);


        bool Exists(int productId);
        HealthProductListViewModel ProductDetailsById(int productId);

    }
}
