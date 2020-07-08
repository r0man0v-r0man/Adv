using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Adv.BLL.DTO.Address;

namespace Adv.BLL.Interfaces
{
    public interface IYandexAddressService
    {
        Task<IList<string>> GetProvinceAsync();
    } 
}
