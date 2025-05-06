using System.ComponentModel.DataAnnotations;

namespace MyGamesLibrary.Models
{
    public class UniqueNameEdit : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;

            string NewName = value.ToString();
            AppDbContext context = new AppDbContext();  
            bool NameExistsInPlayed = context.playedGames.Any(x => x.Name == NewName);
            bool NameExistsInWantsToPlay = context.wantsToPlayGames.Any(y => y.Name == NewName);

            var entity = validationContext.ObjectInstance;

            // If the name exists but belongs to the same record, allow it
            if (NameExistsInPlayed && entity is Played OldName && OldName.Name == NewName)
                return ValidationResult.Success;

            if (NameExistsInWantsToPlay && entity is WantsToPlay OldName2 && OldName2.Name == NewName)
                return ValidationResult.Success;

            // If the name exists in another record, reject it
            if (NameExistsInPlayed != null || NameExistsInWantsToPlay != null)
                return new ValidationResult("This Game Already Exist");

            return ValidationResult.Success;
        }
    }
}
