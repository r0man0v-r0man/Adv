using System;
using System.Collections.Generic;
using Adv.API.Models.Files.Link;
using Adv.BLL.DTO.Images;

namespace Adv.API.Models.Files
{
    public class FileModel
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public long Size { get; set; }
        public string Name { get; set; }
        public Links LinkProps { get; set; }
        /// <summary>
        /// HASH полученный при создании файла, необходим для удаления
        /// </summary>
        public string DeleteHash { get; set; }
        /// <summary>
        /// View -> DTO
        /// </summary>
        /// <param name="fileModel"></param>
        public static implicit operator ImageDto(FileModel fileModel) => new ImageDto
        {
            Id = fileModel.Id,
            Uid = fileModel.Uid,
            Size = fileModel.Size,
            URL = fileModel.LinkProps.Download,
            DeleteHash = fileModel.DeleteHash
        };

        /// <summary>
        /// DTO -> View
        /// </summary>
        /// <param name="dto"></param>
        public static implicit operator FileModel(ImageDto dto) => new FileModel
        {
            Id = dto.Id,
            Uid = dto.Uid,
            Size = dto.Size,
            LinkProps = dto.URL,
            DeleteHash = dto.DeleteHash,
            Name = dto.Uid
        };
    }
}
