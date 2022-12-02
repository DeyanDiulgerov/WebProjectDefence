using WebProject.Models.GamingProductViewModel;

namespace WebProject.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductListViewModel>> AllProductsListAsync();

        Task AddProductForSaleAsync(AddProductViewModel model);

        Task<IEnumerable<ProductListViewModel>> MyProductsAsync(string userId);

        Task AddProductToMyCollection(int productId, string userId);

        Task RemoveFromMyCollection(int productId, string userId);

        bool Exists(int productId);
        ProductListViewModel ProductDetailsById(int productId);

        void Edit(int productId, string name, string company, string imageUrl, string description, DateTime availableFrom,
            int? sales, decimal price, decimal discountPrice);

        void Delete(int productId);
    }
}
