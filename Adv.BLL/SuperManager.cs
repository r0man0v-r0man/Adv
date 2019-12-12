using Adv.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.BLL
{
    public class SuperManager : ISuperManager
    {
        public SuperManager(IFlatService flatService)
        {
            Flats = flatService;
        }
        public IFlatService Flats { get; }
    }
}
