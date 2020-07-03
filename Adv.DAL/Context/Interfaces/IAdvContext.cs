using Adv.DAL.Entities;
using Adv.DAL.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Adv.DAL.Entities.Adverts;

namespace Adv.DAL.Context.Interfaces
{
    public interface IAdvContext : IBaseContext
    {
        DbSet<FlatRent> FlatRents { get; set; }
        DbSet<FlatSale> FlatSales { get; set; }
        DbSet<HouseRent> HouseRents { get; set; }
        DbSet<HouseSale> HouseSales { get; set; }
        DbSet<YandexAddress> YandexAddresses { get; set; }
    }
}
