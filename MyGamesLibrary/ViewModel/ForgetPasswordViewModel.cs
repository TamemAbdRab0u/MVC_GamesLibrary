using System.ComponentModel.DataAnnotations;

namespace MyGamesLibrary.ViewModel
{
    public class ForgetPasswordViewModel
    {
        public string Name { get; set; }

        [Display(Name="New Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmNewPassword { get; set; }
    }
}
