using System.ComponentModel.DataAnnotations;

namespace WebProject.Data.Models
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string DeveloperName { get; set; } = null!;

        [Required]
        public string DeveloperLogoUrl { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;
    }
}
