using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Data.Models
{
    public class UserHealthProduct
    {
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey(nameof(HealthProduct))]
        public int HealthProductId { get; set; }
        public HealthProduct HealthProduct { get; set; }
    }
}
