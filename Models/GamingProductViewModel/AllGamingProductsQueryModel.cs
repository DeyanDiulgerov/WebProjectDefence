using WebProject.Models.Enumerations;

namespace WebProject.Models.GamingProductViewModel
{
    public class AllGamingProductsQueryModel
    {
        public const int ProductsPerPage = 3;

        public string? SearchTerm { get; set; }

        public GamingProductSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalGamingProductsCount { get; set; }

        public IEnumerable<ProductListViewModel> GamingProducts { get; set; } = new List<ProductListViewModel>();
    }
}
