using System;
using System.Collections.Generic;
using System.Text;
using Adv.DAL.Entities.Images;

namespace Adv.BLL.DTO.Images
{
    public class ImageDTO
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

        public static implicit operator Image(ImageDTO dto) => new Image
        {
            Id = dto.Id,
            DeleteHash = dto.DeleteHash,
            URL = dto.URL,
            Uid = dto.Uid,
            Size = dto.Size
        };
    }
}
