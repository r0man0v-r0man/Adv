﻿using System;
using System.Collections.Generic;
using System.Text;
using Adv.DAL.Entities.Adverts;

namespace Adv.DAL.Entities.Images
{
    public class Image
    {
        public int Id { get; set; }
        /// <summary>
        /// уникальная строка для удаления
        /// </summary>
        public string DeleteHash { get; set; }
        /// <summary>
        /// URL картинки
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// уникальный идентификатор, имя
        /// </summary>
        public string Uid { get; set; }
        /// <summary>
        /// размер файла
        /// </summary>
        public long Size { get; set; }

        public FlatRent FlatRent { get; set; }
    }
}
