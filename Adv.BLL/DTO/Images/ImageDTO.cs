using System;
using System.Collections.Generic;
using System.Text;
using Adv.DAL.Entities.Images;

namespace Adv.BLL.DTO.Images
{
    public class ImageDto
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
        /// <summary>
        /// DTO -> DAL
        /// </summary>
        /// <param name="dto"></param>
        public static implicit operator Image(ImageDto dto) => new Image
        {
            Id = dto.Id,
            DeleteHash = dto.DeleteHash,
            URL = dto.URL,
            Uid = dto.Uid,
            Size = dto.Size
        };
        /// <summary>
        /// DAL -> DTO
        /// </summary>
        /// <param name="dal"></param>
        public static implicit operator ImageDto(Image dal) => new ImageDto
        {
            Id = dal.Id,
            DeleteHash = dal.DeleteHash,
            URL = dal.URL,
            Uid = dal.Uid,
            Size = dal.Size
        };
    }
}
