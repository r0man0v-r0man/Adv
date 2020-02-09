using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL.Entities.Enums
{
    public class Duration
    {
        public RentTime RentDuration { get; set; }
        public enum RentTime
        {
            longRent,
            shortRent
        }
    }
}
