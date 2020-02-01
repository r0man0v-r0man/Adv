using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.BLL.Interfaces
{
    public interface ISuperManager
    {
        IFlatService Flats { get; set; }
        IFileService Files { get; set; }
        IUserService Users { get; set; }
    }
}
