using Adv.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.BLL
{
    public class SuperManager : ISuperManager
    {
        public SuperManager(
            IFlatService flatService,
            IFileService fileService
            )
        {
            Flats = flatService;
            Files = fileService;
        }
        public IFlatService Flats { get; }
        public IFileService Files { get; }
    }
}
