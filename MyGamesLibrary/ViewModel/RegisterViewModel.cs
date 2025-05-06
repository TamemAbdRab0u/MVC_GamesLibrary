using System.ComponentModel.DataAnnotations;

namespace MyGamesLibrary.ViewModel
{
    public class RegisterViewModel
    {
        public string Name { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassowrd {  get; set; }

        public string RoleName { get; set; }
    }
}
