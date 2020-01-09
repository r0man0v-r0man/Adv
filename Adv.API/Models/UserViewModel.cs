using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Adv.API.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        /// <summary>
        /// Mapping to UserViewModel
        /// </summary>
        /// <param name="identityUser"></param>
        public static implicit operator UserViewModel(IdentityUser identityUser) => new UserViewModel
        {
            UserName = identityUser?.UserName,
            Id = identityUser.Id
        };
        /// <summary>
        /// Mapping to IdentityUser
        /// </summary>
        /// <param name="userViewModel"></param>
        public static implicit operator IdentityUser(UserViewModel userViewModel) => new IdentityUser
        {
            UserName = userViewModel?.UserName,
            NormalizedUserName = userViewModel.UserName.ToUpper(CultureInfo.GetCultureInfo(1049))
        };
    }
}
