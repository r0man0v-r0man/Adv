using Adv.DAL.Entities.Adverts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// объявления квартира сдать
        /// </summary>
        public List<FlatRent> FlatRents { get; set; }
        /// <summary>
        /// объявления квартира продать
        /// </summary>
        public List<FlatSale> FlatSales { get; set; }
        /// <summary>
        /// объявления дом сдать
        /// </summary>
        public List<HouseRent> HouseRents { get; set; }
        /// <summary>
        /// объявления дом продать
        /// </summary>
        public List<HouseSale> HouseSales { get; set; }
    }
}
