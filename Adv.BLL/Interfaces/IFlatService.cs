﻿using Adv.BLL.DTO;
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
    }
}
