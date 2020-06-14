using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adv.API.Models
{
    public class FilterOptions
    {
        public int PageNumber { get; set; }
        public CityViewModel City { get; set; }
    }

}
