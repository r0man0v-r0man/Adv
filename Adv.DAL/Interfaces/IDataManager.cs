using Adv.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL.Interfaces
{
    public interface IDataManager
    {
        IFlatRepository Flats { get; }
        IUserRepository Users { get; }
        IFileRepository Files { get; }
    }
}
