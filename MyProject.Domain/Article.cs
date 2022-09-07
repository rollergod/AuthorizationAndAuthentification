using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Domain
{
    public class Article 
    {
        /// <summary>
        /// Ид статьи
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Ид создателя
        /// </summary>
        public int UserId { get; set; }
        public User User { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Короткое описание статьи
        /// </summary>
        [Required]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Содержание статьи
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Название изображения
        /// </summary>
        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        /// <summary>
        /// Дата создания статьи
        /// </summary>
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [NotMapped]
        [DisplayName("Upload File")]
        //[Required]
        public IFormFile ImageFile { get; set; }

        /// <summary>
        /// Метод для получения даты создания
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetData(Article model)
        {
            int createDate = Convert.ToInt32(model.CreateDate.ToString("dd"));
            int dateNow = Convert.ToInt32(DateTime.Now.ToString("dd"));

            if (createDate == dateNow)
                return $"Сегодня, {model.CreateDate.ToString("HH:mm")}";
            else if (dateNow - createDate == 1)
                return $"Вчера, {model.CreateDate.ToString("HH:mm")}";
            else
                return $"{model.CreateDate.ToString("dd MMMM, HH:MM")}";

        }
    }
}
