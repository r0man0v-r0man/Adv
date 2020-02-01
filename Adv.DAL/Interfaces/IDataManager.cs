using Adv.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL.Interfaces
{
    public interface IDataManager
    {
        IFlatRepository Flats { get; set; }
        IUserRepository Users { get; set; }
    }
}
