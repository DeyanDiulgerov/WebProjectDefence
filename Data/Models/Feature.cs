using System.ComponentModel.DataAnnotations;

namespace WebProject.Data.Models
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; } = null!;
    }
}
