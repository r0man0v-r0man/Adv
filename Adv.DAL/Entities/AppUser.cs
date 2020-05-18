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
    }
}
