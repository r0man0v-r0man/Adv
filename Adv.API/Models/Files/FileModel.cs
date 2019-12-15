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

    }
}
