using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DOMAIN.Enums
{
    public class City
    {
        public District DistrictName { get; set; }
        public enum District
        {
            factory,
            leninsky,
            moscow,
            october,
            partisan,
            firstMay,
            sovet,
            central,
            frunzensky
        }
    }
}
