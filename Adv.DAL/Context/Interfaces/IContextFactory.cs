using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL.Context.Interfaces
{
    public interface IContextFactory : IDisposable
    {
        IAdvContext GetAdvContext();
    }
}
