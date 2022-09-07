using MyProject.Domain;

namespace MyProject.Services
{ 
    public interface IGetData
    {
        /// <summary>
        /// Интерфейс, содержащий в себе метод для даты создания статьи.
        /// </summary>
        public string GetData(Article model);
    }
}
