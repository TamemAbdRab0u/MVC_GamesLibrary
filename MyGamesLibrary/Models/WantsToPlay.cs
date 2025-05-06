using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MyGamesLibrary.Models
{
    public class WantsToPlay
    {
        [Key]
        [Required(ErrorMessage = "Game Name Is Required")]
        [MinLength(3, ErrorMessage = "Minimmum 3 Letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Game Type Is Rerquired")]
        public string GameType { get; set; }

        public string? Company { get; set; }
        public string Size { get; set; }

        [Required(ErrorMessage = "Status Is Required")]
        public string Status { get; set; }
    }
}

