using Microsoft.AspNetCore.Hosting;
using MyProject_AuthorizationAndAuthentification.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject_AuthorizationAndAuthentification.Services
{
    /// <summary>
    /// Класс для работы с изображениями
    /// </summary>
    public class Image : ICreateImage
    {
        private string Filename { get; set; }
        private string Extension { get; set; }
        private string FilePath { get;set; }
        private readonly IWebHostEnvironment _hostEnvironment;
        public Image(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        /// <summary>
        /// Создание или обновление изображения
        /// </summary>
        /// <param name="model">Основная статья</param>
        /// <param name="type">Тип изображения</param>
        /// <param name="oldModel">Старая статья, необходима, если меняем изображения</param>
        public async Task CreateImage(Article model,ImageTypes type,Article oldModel = null)
        {
            string wwwRoothPath = _hostEnvironment.WebRootPath;

            Filename = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            Extension = Path.GetExtension(model.ImageFile.FileName);

            if (type == ImageTypes.Create)
            {
                model.ImageName = Filename = Filename + DateTime.Now.ToString("yymmssfff") + Extension;
            }
            else if(type == ImageTypes.Update)
            {
                oldModel.ImageName = Filename = Filename + DateTime.Now.ToString("yymmssfff") + Extension;
            }

             FilePath = Path.Combine(wwwRoothPath + "/Images/", Filename);

            using (var fileStream = new FileStream(FilePath, FileMode.Create))
            {
                await model.ImageFile.CopyToAsync(fileStream);
            }
        }
    }
}
