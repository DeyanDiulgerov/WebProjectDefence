namespace WebProject.Models.HealthProductViewModel
{
    public class HealthQueryModel
    {
        public int TotalHealthProductsCount { get; set; }

        public IEnumerable<HealthProductListViewModel> HealthProducts { get; set; } = new List<HealthProductListViewModel>();
    }
}
