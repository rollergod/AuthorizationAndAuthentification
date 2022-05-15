using MyProject_AuthorizationAndAuthentification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject_AuthorizationAndAuthentification.Services
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
