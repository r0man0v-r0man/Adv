using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DOMAIN.Common
{
    public class AuditableEntity
    {
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
