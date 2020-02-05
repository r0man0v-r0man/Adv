using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL.Entities.Common
{
    public abstract class AuditableEntity : IAuditableEntity
    {
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
