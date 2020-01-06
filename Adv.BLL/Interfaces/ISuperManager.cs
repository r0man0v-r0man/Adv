using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.BLL.Interfaces
{
    public interface ISuperManager
    {
        IFlatService Flats { get; }
        IFileService Files { get; }
        IUserService Users { get; }
    }
}
