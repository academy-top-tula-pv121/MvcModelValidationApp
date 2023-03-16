using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MvcModelValidationApp.Models
{
    public class User
    {
        /*
         [CreditCard] 
         [EmailAddress]
         [Phone]
         [Url]
        */
        [Required(ErrorMessage = "Не указано имя")]
        [UserName(new string[] {"Bob", "Joe"}, ErrorMessage = "Недопустимые имена")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Не указана почта")]
        [RegularExpression(@"^[A-Za-z0-9]+@[A-Za-z0-9]+\.[A-Za-z0-9]{2,5}$", ErrorMessage = "Некорректная почта")]
        public string? Email { get; set; }

        [Remote(action: "CheckCode", controller: "Home", ErrorMessage = "Код не подходит")]
        public string? Code { set; get; }

        [Required(ErrorMessage = "Не задан пароль")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина пароля от 3 до 50 символов")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Не задан пароль")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина пароля от 3 до 50 символов")]
        [Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        public string? PasswordConfirm { get; set; }

        [Range(1, 100, ErrorMessage = "Возраст должен быть от 1 до 100")]
        public int? Age { get; set; }
    }
}
