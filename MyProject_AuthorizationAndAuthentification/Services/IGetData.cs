using MyProject_AuthorizationAndAuthentification.Models;

namespace MyProject_AuthorizationAndAuthentification.Services
{
    public interface IGetData
    {
        /// <summary>
        /// Интерфейс, содержащий в себе метод для даты создания статьи.
        /// </summary>
        public string GetData(Article model);
    }
}
