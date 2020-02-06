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
            IUserRepository userRepository,
            IFileRepository fileRepository
            )
        {
            this.Flats = flatRepository;
            this.Users = userRepository;
            this.Files = fileRepository;
        }
        public IFlatRepository Flats { get; }
        public IUserRepository Users { get; }
        public IFileRepository Files { get; }
    }
}
