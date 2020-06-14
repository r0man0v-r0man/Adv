using Adv.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Adv.DAL.Interfaces
{
    public interface ICityRepository : IBaseRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
    }
}
