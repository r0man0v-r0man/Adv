using Adv.DAL.Entities;
using Adv.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL
{
    public class DataManager : IDataManager
    {
        public DataManager(
            IFlatRepository flatRepository,
            IUserRepository userRepository
            )
        {
            this.Flats = flatRepository;
            this.Users = userRepository;
        }
        public IFlatRepository Flats { get; set; }
        public IUserRepository Users { get; set; }

    }
}
