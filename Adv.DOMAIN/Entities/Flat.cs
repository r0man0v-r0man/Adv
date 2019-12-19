using Adv.DOMAIN.Common;
using Adv.DOMAIN.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DOMAIN.Entities
{
    public abstract class Flat : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public City.District District { get; set; }

        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }

}
