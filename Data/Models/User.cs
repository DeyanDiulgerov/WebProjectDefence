using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<UserGame> UserGames { get; set; } = new List<UserGame>();

        public ICollection<UserGamingProduct> UserGamingProducts { get; set; } = new List<UserGamingProduct>();

        public ICollection<UserHealthProduct> UsersHealthProducts { get; set; } = new List<UserHealthProduct>();
    }
}
