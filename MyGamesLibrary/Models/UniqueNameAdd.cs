using System.ComponentModel.DataAnnotations;

namespace MyGamesLibrary.Models
{
    public class UniqueNameAdd : ValidationAttribute
    {
        public class UniqueNameAttribute : ValidationAttribute
        {
            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                if (value == null)
                    return null;

                string NewName = value.ToString();
                AppDbContext context = new AppDbContext();
                Played OldName = context.playedGames.FirstOrDefault(x => x.Name == NewName);
                WantsToPlay OldName2 = context.wantsToPlayGames.FirstOrDefault(y => y.Name == NewName);

                if (OldName != null || OldName2 != null)
                    return new ValidationResult("This Game Already Exist");
                return ValidationResult.Success;
            }
        }
    }
}
