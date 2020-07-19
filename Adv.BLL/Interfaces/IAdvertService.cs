using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Adv.BLL.DTO.Adverts;
using Adv.BLL.DTO;
using Adv.BLL.DTO.Address;

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
        Task<int> CreateFlatRentAsync(FlatRentDto flatRentDto, CancellationToken ct);
        /// <summary>
        /// Создание объявления квартира-продать
        /// </summary>
        /// <param name="flatSaleDto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<int> CreateFlatSaleAsync(FlatSaleDto flatSaleDto, CancellationToken ct);
        /// <summary>
        /// Создание объявления дом-сдать
        /// </summary>
        /// <param name="houseRentDto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<int> CreateHouseRentAsync(HouseRentDto houseRentDto, CancellationToken ct);
        /// <summary>
        /// Создание объявления дом-продать
        /// </summary>
        /// <param name="houseSaleDto"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<int> CreateHouseSaleAsync(HouseSaleDto houseSaleDto, CancellationToken ct);
        /// <summary>
        /// Получение объявления
        /// </summary>
        /// <param name="id">номер объявления</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<FlatRentDto> GetFlatRentAsync(int id, CancellationToken ct);
        /// <summary>
        /// Получение объявления
        /// </summary>
        /// <param name="id">номер объявления</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<FlatSaleDto> GetFlatSaleAsync(int id, CancellationToken ct);
        /// <summary>
        /// Получение объявления
        /// </summary>
        /// <param name="id">номер объявления</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<HouseRentDto> GetHouseRentAsync(int id, CancellationToken ct);
        /// <summary>
        /// Получение объявления
        /// </summary>
        /// <param name="id">номер объявления</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<HouseSaleDto> GetHouseSaleAsync(int id, CancellationToken ct);
        Task<IEnumerable<FlatRentDto>> GetFlatRentsAsync(int pageNumber, ComponentDto province);
        Task<IEnumerable<FlatSaleDto>> GetFlatSalesAsync(int pageNumber, ComponentDto province);
        Task<IEnumerable<HouseRentDto>> GetHouseRentsAsync(int pageNumber, ComponentDto province);
        Task<IEnumerable<HouseSaleDto>> GetHouseSalesAsync(int pageNumber, ComponentDto province);
        Task<IEnumerable<FlatRentDto>> GetAnyFlatRentsAsync(int pageNumber);
        Task<IEnumerable<FlatSaleDto>> GetAnyFlatSalesAsync(int pageNumber);
        Task<IEnumerable<HouseRentDto>> GetAnyHouseRentsAsync(int pageNumber);
        Task<IEnumerable<HouseSaleDto>> GetAnyHouseSalesAsync(int pageNumber);
    }
}
