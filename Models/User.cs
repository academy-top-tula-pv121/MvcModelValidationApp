using System.ComponentModel.DataAnnotations;

namespace MvcModelValidationApp.Models
{
    public class User
    {
        [Required]
        public string? Name { get; set; }

        public int? Age { get; set; }
    }
}
