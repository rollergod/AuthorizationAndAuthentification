using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service
{
    /// <summary>
    /// Перечисление, для определения типа фотографии
    /// </summary>
    public enum ImageTypes
    {
        Create, //Фотография для создания статьи
        Update, //Обновление фотографии статьи
    }
}
