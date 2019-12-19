using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adv.API.Models.Files.Link
{
    public class Links
    {
        public string Download { get; set; }
        /// <summary>
        /// Mapping string to links model
        /// </summary>
        /// <param name="image">string of path to image file</param>
        public static implicit operator Links(string image) =>
            new Links
            {
                Download = image
            };
    }
}
