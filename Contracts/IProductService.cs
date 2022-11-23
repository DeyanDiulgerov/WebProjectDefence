using WebProject.Models;

namespace WebProject.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductListViewModel>> AllProductsListAsync();

        Task AddProductForSaleAsync(AddProductViewModel model);

        Task<IEnumerable<ProductListViewModel>> MyProductsAsync(string userId);

        Task AddProductToMyCollection(int productId, string userId);

        Task RemoveFromMyCollection(int productId, string userId);
    }
}
