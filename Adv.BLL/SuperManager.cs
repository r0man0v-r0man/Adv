using Adv.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.BLL
{
    public class SuperManager : ISuperManager
    {
        public IFlatService Flats { get; set; }
        public IFileService Files { get; set; }
        public IUserService Users { get; set; }
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
