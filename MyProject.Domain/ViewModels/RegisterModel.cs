using System.ComponentModel.DataAnnotations;

namespace MyProject.Domain.ViewModels
{
    /// <summary>
    /// Класс содержащий поля для страницы регистрации
    /// </summary>
    public class RegisterModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
