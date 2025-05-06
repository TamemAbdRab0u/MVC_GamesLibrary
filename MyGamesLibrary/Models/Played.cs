using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyGamesLibrary.Models
{
    public class Played
    {
        [Key]
        [Required(ErrorMessage = "Game Name Is Required")]
        [MinLength(3,ErrorMessage ="Minimmum 3 Letters")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Game Type Is Rerquired")]
        public string GameType { get; set; }
        public string? Company { get; set; }

        [Required(ErrorMessage = "Size Is Required")]
        public string Size { get; set; }
        public bool LikeIt { get; set; }

        [Required(ErrorMessage = "Status Is Required")]
        public string Status { get; set; }
    }
}

