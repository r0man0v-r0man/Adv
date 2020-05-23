using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Adv.BLL.DTO.Adverts;

namespace Adv.BLL.Interfaces
{
    public interface IAdvertService
    {
        /// <summary>
        /// Создание объявления квартира-сдать
        /// </summary>
        /// <param name="flatRentDto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<FlatRentDto> CreateFlatRentAsync(FlatRentDto flatRentDto, CancellationToken ct);
        /// <summary>
        /// Создание объявления квартира-продать
        /// </summary>
        /// <param name="flatSaleDto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<FlatSaleDto> CreateFlatSaleAsync(FlatSaleDto flatSaleDto, CancellationToken ct);
        /// <summary>
        /// Создание объявления дом-сдать
        /// </summary>
        /// <param name="houseRentDto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<HouseRentDto> CreateHouseRentAsync(HouseRentDto houseRentDto, CancellationToken ct);
        /// <summary>
        /// Создание объявления дом-продать
        /// </summary>
        /// <param name="houseSaleDto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<HouseSaleDto> CreateHouseSaleAsync(HouseSaleDto houseSaleDto, CancellationToken ct);
    }
}
