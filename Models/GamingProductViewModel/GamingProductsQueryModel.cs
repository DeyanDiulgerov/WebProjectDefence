using WebProject.Models.GameViewModel;

namespace WebProject.Models.GamingProductViewModel
{
    public class GamingProductsQueryModel
    {
        public int TotalGamingProductsCount { get; set; }

        public IEnumerable<ProductListViewModel> GamingProducts { get; set; } = new List<ProductListViewModel>();
    }
}
