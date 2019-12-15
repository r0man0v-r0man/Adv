using Adv.DOMAIN.Common;
using Adv.DOMAIN.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DOMAIN.Entities
{
    public class Flat : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public City.District DistrictName { get; set; }

    }

}
