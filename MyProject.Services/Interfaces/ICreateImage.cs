
using MyProject.Domain;
using System.Threading.Tasks;

namespace MyProject.Service
{
    /// <summary>
    /// Интерфейс для создания изображений
    /// </summary>
    public interface ICreateImage
    {
        /// <summary>
        /// Метод для создания изображений
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <param name="oldModel"></param>
        public Task CreateImage(Article model, ImageTypes type, Article oldModel = null);
    }
}
