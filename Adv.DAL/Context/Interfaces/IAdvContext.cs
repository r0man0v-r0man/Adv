using Adv.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Adv.DAL.Entities.Adverts;

namespace Adv.DAL.Context.Interfaces
{
    public interface IAdvContext : IBaseContext
    {
        DbSet<FlatRent> FlatRents { get; set; }
        DbSet<FlatSale> FlatSales { get; set; }
        DbSet<HouseRent> HouseRents { get; set; }
    }
}
