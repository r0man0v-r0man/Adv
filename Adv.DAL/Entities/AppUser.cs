using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Adv.DAL.Entities
{
    public class AppUser : IdentityUser, DOMAIN.Interfaces.IAppUser
    {
        public List<Flat> Flats { get; set; }
    }
}
