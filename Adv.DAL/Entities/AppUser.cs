using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Adv.DAL.Entities
{
    public class AppUser : IdentityUser
    {
        public List<Flat> Flats { get; set; }
    }
}
