using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL.Entities.Adverts.Update
{
    public class UpdateAdvert
    {
        /// <summary>
        /// цена
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// телефон
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// описание
        /// </summary>
        public string Description { get; set; }
    }
}
