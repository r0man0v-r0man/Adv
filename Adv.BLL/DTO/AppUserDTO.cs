using Adv.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Adv.BLL.DTO
{
    public class AppUserDTO
    {
        /// <summary>
        /// Unique identificator
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// User Name - Login
        /// </summary>
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public List<FlatDTO> flatDTOs { get; set; }

        /// <summary>
        /// Mapping to AppUserDTO
        /// </summary>
        /// <param name="identityUser"></param>
        public static implicit operator AppUserDTO(AppUser appUser) => new AppUserDTO
        {
            UserName = appUser?.UserName,
            Id = appUser.Id,
            flatDTOs = appUser.Flats
                .Select(flat => new FlatDTO())
                .ToList()
        };
        /// <summary>
        /// Mapping to AppUser
        /// </summary>
        /// <param name="userViewModel"></param>
        public static implicit operator AppUser(AppUserDTO appUserDTO) => new AppUser
        {
            UserName = appUserDTO?.UserName,
            NormalizedUserName = appUserDTO.UserName.ToUpper(CultureInfo.GetCultureInfo(1049))
        };
    }
}
