using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Adv.DAL.Entities.Adverts;

namespace Adv.DAL.Interfaces
{
    public interface IAdvertRepository : IBaseRepository
    {        
        /// <summary>
        /// создание объявления квартира-сдать
        /// </summary>
        /// <param name="flatRent"></param>
        /// <param name="ct"></param>
        /// <returns>объявление</returns>
        Task<FlatRent> CreateFlatRentAsync(FlatRent flatRent, CancellationToken ct);
        /// <summary>
        /// создание объявления квартира-продать
        /// </summary>
        /// <param name="flatSale"></param>
        /// <param name="ct"></param>
        /// <returns>объявление</returns>
        Task<FlatSale> CreateFlatSaleAsync(FlatSale flatSale, CancellationToken ct);
        /// <summary>
        /// создание объявления дом-сдать
        /// </summary>
        /// <param name="houseRent"></param>
        /// <param name="ct"></param>
        /// <returns>объявление</returns>
        Task<HouseRent> CreateHouseRentAsync(HouseRent houseRent, CancellationToken ct);
        /// <summary>
        /// создание объявления дом-продать
        /// </summary>
        /// <param name="houseSale"></param>
        /// <param name="ct"></param>
        /// <returns>объявление</returns>
        Task<HouseSale> CreateHouseSaleAsync(HouseSale houseSale, CancellationToken ct);
    }
}
