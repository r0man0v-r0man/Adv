using Adv.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL.Context.Interfaces
{
    public interface IAdvContext : IBaseContext
    {
        DbSet<Flat> Flats { get; set; }
    }
}
