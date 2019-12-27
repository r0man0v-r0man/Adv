using Adv.DAL.Entities;
using Adv.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL
{
    public class DataManager : IDataManager
    {
        public DataManager(IFlatRepository flatRepository)
        {
            this.Flats = flatRepository;
        }
        public IFlatRepository Flats { get; }
    }
}
