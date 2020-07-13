using System.Collections.Generic;
using System.Threading.Tasks;
using Adv.DAL.Entities.Address;

namespace Adv.DAL.Interfaces
{
    public interface IYandexAddressRepository
    {
        Task<IList<Component>> GetLocationsAsync();
    }
}
