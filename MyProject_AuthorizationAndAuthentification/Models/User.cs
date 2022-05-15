namespace MyProject_AuthorizationAndAuthentification.Models
{
    public class User
    {
        /// <summary>
        /// Ид пользователя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Ник пользователя
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Почта пользователя
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int? Age { get; set; }
        /// <summary>
        /// Ид роли у пользователя
        /// </summary>
        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}
