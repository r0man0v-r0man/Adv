using Adv.DAL.Entities;
using Adv.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL
{
    public class DataManager : IDataManager
    {
        private readonly IRepository<Flat> flatRepository;
        public DataManager(IRepository<Flat> flatRepository)
        {
            this.flatRepository = flatRepository;
        }
        public IRepository<Flat> GetFlatRepository()
        {
            return flatRepository;
        }
    }
}
