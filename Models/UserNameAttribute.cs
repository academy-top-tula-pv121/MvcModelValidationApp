using System.ComponentModel.DataAnnotations;

namespace MvcModelValidationApp.Models
{
    public class UserNameAttribute : ValidationAttribute
    {
        string[] wrongWords;
        public UserNameAttribute(string[] wrongWords)
        {
            this.wrongWords = wrongWords;
        }
        public override bool IsValid(object? value)
        {
            if (value == null)
                return false;
            return !wrongWords.Contains((string)value);
        }
    }
}
