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

        public static implicit operator ImageDTO(FileModel fileModel) => new ImageDTO
        {
            Id = fileModel.Id,
            Uid = fileModel.Uid,
            Size = fileModel.Size,
            URL = fileModel.LinkProps.Download,
            DeleteHash = fileModel.DeleteHash
        };
    }
}
