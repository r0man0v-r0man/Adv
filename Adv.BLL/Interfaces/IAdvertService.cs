﻿using System;
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
    }
}
