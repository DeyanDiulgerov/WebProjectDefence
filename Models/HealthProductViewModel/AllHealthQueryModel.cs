using WebProject.Models.Enumerations;

namespace WebProject.Models.HealthProductViewModel
{
    public class AllHealthQueryModel : HealthQueryModel
    {
        public const int HealthyProudctsPerPage = 3;

        public string? SearchTerm { get; set; }

        public int CurrentPage { get; set; } = 1;

        public HealthSorting Sorting { get; set; }
    }
}
