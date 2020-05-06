using System;
using System.Collections.Generic;
using Adv.API.Models.Files.Link;

namespace Adv.API.Models.Files
{
    public class FileModel
    {
        public string Uid { get; set; }
        public long Size { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Links LinkProps { get; set; }
        /// <summary>
        /// HASH полученный при создании файла, необходим для удаления
        /// </summary>
        public string DeleteHash { get; set; }

        /// <summary>
        /// Mapping to string
        /// </summary>
        /// <param name="file"></param>
        public static implicit operator string(FileModel file)
        {
            return file?.LinkProps.Download;
        }
    }
}
