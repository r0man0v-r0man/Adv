using Adv.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.BLL
{
    public class SuperManager : ISuperManager
    {
        public IFlatService Flats { get; }
        public IFileService Files { get; }
        public IUserService Users { get; }
        public SuperManager(
            IFlatService flatService,
            IFileService fileService,
            IUserService userService
            )
        {
            Flats = flatService;
            Files = fileService;
            Users = userService;
        }

    }
}
