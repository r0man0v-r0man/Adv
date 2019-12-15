using Adv.API.Models.Enums;
using Adv.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adv.API.Models
{
    public class FlatViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public City.District District { get; set; }
    }
}
