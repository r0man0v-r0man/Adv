using Adv.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adv.DAL.Context.Interfaces
{
    public interface IStoreCityContext : IBaseContext
    {
        DbSet<StoreCity> Cities { get; set; }
    }
}