using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adv.API.Models.Criteria
{
    public class SearchFlatCriteria
    {
        public byte City { get; set; }
        public byte Rooms { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public byte RentType { get; set; }

    }
}
