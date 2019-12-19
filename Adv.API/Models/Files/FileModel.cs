using System;
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
        /// Mapping to FileModel from string
        /// </summary>
        /// <param name="image">Path to the image</param>
        public static implicit operator FileModel(string image) =>
            new FileModel
            {
                LinkProps = image
            };

        public static implicit operator string(FileModel file)
        {
            return file.LinkProps.Download;
        }
    }
}
