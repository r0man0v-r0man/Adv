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
        Task<FlatDTO> GetAsync(int id);
        IAsyncEnumerable<FlatDTO> GetAsync(CancellationToken ct);
        IAsyncEnumerable<FlatDTO> GetAsync(int pageNumber, byte size, int skip, CancellationToken ct);
        Task<FlatDTO> CreateAsync(FlatDTO newFlat, CancellationToken ct);
    }
}
