using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebProject.Data.Models;

namespace WebProject.Models.AdminViewModel
{
    public class PotentialAdminViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; } = null!;

        public string UserId { get; set; }
    }
}
