using Adv.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL.Interfaces
{
    public interface IDataManager
    {
        IFlatRepository Flats { get; }
    }
}
