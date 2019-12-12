using Adv.DAL.Entities;
using Adv.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL
{
    public class DataManager : IDataManager
    {
        public DataManager(IRepository<Flat> flatRepository)
        {
            this.Flats = flatRepository;
        }
        public IRepository<Flat> Flats { get; }
    }
}
