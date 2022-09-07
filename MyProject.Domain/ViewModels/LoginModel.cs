using System.ComponentModel.DataAnnotations;

namespace MyProject.Domain.ViewModels
{
    /// <summary>
    /// Класс содержащий поля для страницы авторизации
    /// </summary>
    public class LoginModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
