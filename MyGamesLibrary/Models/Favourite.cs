using System.ComponentModel.DataAnnotations;

namespace MyGamesLibrary.Models
{
    public class Favourite
    {
        [Key]
        public string Name { get; set; }
        public string GameType { get; set; }
        public string? Company { get; set; }
        public string Size { get; set; }
        public bool LikeIt { get; set; }
        public string Status { get; set; }
    }
}
