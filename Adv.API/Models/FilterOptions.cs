using Adv.API.Models.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adv.API.Models
{
    public class FilterOptions
    {
        /// <summary>
        /// город, район, область
        /// </summary>
        public ComponentViewModel Province { get; set; }
    }

}
