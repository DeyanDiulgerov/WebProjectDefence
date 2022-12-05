using System.ComponentModel.DataAnnotations;

namespace WebProject.Models.AdminViewModel
{
    public class BecomeAdminViewModel
    {
        [Phone]
        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(15, MinimumLength = 7)]
        public string PhoneNumber { get; init; } = null!;
    }
}
