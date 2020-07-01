using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Adv.DAL.Entities.Adverts;

namespace Adv.DAL.Entities
{
    public class AppUser : IdentityUser
    {
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
