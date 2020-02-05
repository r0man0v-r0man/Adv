using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL.Entities.Common
{
    public interface IAuditableEntity
    {
        DateTime Created { get; set; }
        DateTime LastModified { get; set; }
    }
}
