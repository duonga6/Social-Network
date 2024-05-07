using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Business.Utilities.Validation
{
    public class NotEmptyOrWhiteSpaceAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            string? str = value?.ToString()?.Trim();
            return str?.Length > 0;
        }
    }
}
