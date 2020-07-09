using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adv.DAL.Interfaces
{
    public interface IYandexAddressRepository
    {
        Task<IList<string>> GetLocationsAsync();
    }
}
