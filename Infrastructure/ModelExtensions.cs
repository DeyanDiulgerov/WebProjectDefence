using System.Text.RegularExpressions;
using WebProject.Models.GameViewModel;

namespace WebProject.Infrastructure
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IGameModel game)
            => game.GameName.Replace(" ", "-") + "-" + GetDeveloper(game.Developer);

        private static string GetDeveloper(string developer)
        {
            developer = string.Join("-", developer.Split(" ").Take(3));
            return Regex.Replace(developer, @"[^a-zA-Z0-9\-]", string.Empty);
        }
    }
}
