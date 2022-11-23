using Microsoft.AspNetCore.Identity;

namespace WebProject.Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<UserGame> UserGames { get; set; } = new List<UserGame>();

        public ICollection<UserProduct> UserProducts { get; set; } = new List<UserProduct>();
    }
}
