using Adv.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adv.BLL.Interfaces
{
    public interface IFlatService
    {
        Task<FlatDTO> GetAsync(int id, CancellationToken ct);
        Task<List<FlatDTO>> GetAllAsync(int pageNumber, byte size, int skip, CancellationToken ct);
        Task<FlatDTO> CreateAsync(FlatDTO newFlat, CancellationToken ct);
        /// <summary>
        /// delete flat with images
        /// </summary>
        /// <param name="flatId"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int flatId, CancellationToken ct);
        /// <summary>
        /// update properties
        /// </summary>
        /// <param name="updatedFlat">new properties</param>
        /// <param name="id">id of flat</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(FlatUpdateDTO updatedProperties, int id, CancellationToken ct);
        /// <summary>
        /// Find flats by criteria
        /// </summary>
        /// <param name="city">city</param>
        /// <param name="rooms">the count of rooms</param>
        /// <param name="priceMin">price from</param>
        /// <param name="priceMax">price to</param>
        /// <param name="rentType">long or short</param>
        /// <returns></returns>
        Task<IEnumerable<FlatDTO>> FindByCriteriaAsync(byte city, byte rooms, decimal priceMin, decimal priceMax, byte rentType, int pageNumber, byte size, int skip);
    }
}
