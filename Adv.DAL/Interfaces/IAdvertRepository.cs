﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Adv.DAL.Entities.Adverts;
using Adv.DAL.Entities;

namespace Adv.DAL.Interfaces
{
    public interface IAdvertRepository : IBaseRepository
    {        
        /// <summary>
        /// создание объявления квартира-сдать
        /// </summary>
        /// <param name="flatRent"></param>
        /// <param name="ct"></param>
        /// <returns>id</returns>
        Task<int> CreateFlatRentAsync(FlatRent flatRent, CancellationToken ct);
        /// <summary>
        /// создание объявления квартира-продать
        /// </summary>
        /// <param name="flatSale"></param>
        /// <param name="ct"></param>
        /// <returns>id</returns>
        Task<int> CreateFlatSaleAsync(FlatSale flatSale, CancellationToken ct);
        /// <summary>
        /// создание объявления дом-сдать
        /// </summary>
        /// <param name="houseRent"></param>
        /// <param name="ct"></param>
        /// <returns>id</returns>
        Task<int> CreateHouseRentAsync(HouseRent houseRent, CancellationToken ct);
        /// <summary>
        /// создание объявления дом-продать
        /// </summary>
        /// <param name="houseSale"></param>
        /// <param name="ct"></param>
        /// <returns>id</returns>
        Task<int> CreateHouseSaleAsync(HouseSale houseSale, CancellationToken ct);
        /// <summary>
        /// Получение объявления
        /// </summary>
        /// <param name="id">номер объявления</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<FlatRent> GetFlatRentAsync(int id, CancellationToken ct);
        /// <summary>
        /// Получение объявления
        /// </summary>
        /// <param name="id">номер объявления</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<FlatSale> GetFlatSaleAsync(int id, CancellationToken ct);

        /// <summary>
        /// Получение объявления
        /// </summary>
        /// <param name="id">номер объявления</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<HouseRent> GetHouseRentAsync(int id, CancellationToken ct);
        /// <summary>
        /// Получение объявления
        /// </summary>
        /// <param name="id">номер объявления</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<HouseSale> GetHouseSaleAsync(int id, CancellationToken ct);
        // /// <summary>
        // /// получить объявления квартира-сдать
        // /// </summary>
        // /// <param name="pageNumber"></param>
        // /// <param name="city"></param>
        // /// <returns></returns>
        // Task<IEnumerable<FlatRent>> GetFlatRents(int pageNumber, City city);
        // /// <summary>
        // /// получить объявления квартира-продать
        // /// </summary>
        // /// <param name="pageNumber"></param>
        // /// <param name="city"></param>
        // /// <returns></returns>
        // Task<IEnumerable<FlatSale>> GetFlatSales(int pageNumber, City city);
        // /// <summary>
        // /// получить объявления дом-сдать
        // /// </summary>
        // /// <param name="pageNumber"></param>
        // /// <param name="city"></param>
        // /// <returns></returns>
        // Task<IEnumerable<HouseRent>> GetHouseRents(int pageNumber, City city);
        // /// <summary>
        // /// получить объявления дом-продать
        // /// </summary>
        // /// <param name="pageNumber"></param>
        // /// <param name="city"></param>
        // /// <returns></returns>
        // Task<IEnumerable<HouseSale>> GetHouseSales(int pageNumber, City city);
        /// <summary>
        /// получить любые объявления квартира-сдать
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        Task<IEnumerable<FlatRent>> GetAnyFlatRentsAsync(int pageNumber);
        /// <summary>
        /// получить любые объявления квартира-продать
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        Task<IEnumerable<FlatSale>> GetAnyFlatSalesAsync(int pageNumber);
        /// <summary>
        /// получить любые объявления дом-сдать
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        Task<IEnumerable<HouseRent>> GetAnyHouseRentsAsync(int pageNumber);
        /// <summary>
        /// получить любые объявления дом-продать
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        Task<IEnumerable<HouseSale>> GetAnyHouseSalesAsync(int pageNumber);

        // Task<(IEnumerable<FlatRent> flatRents, IEnumerable<FlatSale> flatSales, IEnumerable<HouseRent> houseRents,
        //     IEnumerable<HouseSale> houseSales)> GetUserAdverts(AppUser user, int pageNumber);
    }
}
