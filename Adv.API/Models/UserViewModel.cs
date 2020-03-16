using Adv.API.Models.Flat;
using Adv.BLL.DTO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
        public static implicit operator UserViewModel(AppUserDTO appUserDTO) => new UserViewModel
        {
            UserName = appUserDTO?.UserName,
            Id = appUserDTO.Id
        };
        /// <summary>
        /// Mapping to AppUserDTO
        /// </summary>
        /// <param name="userViewModel"></param>
        public static implicit operator AppUserDTO(UserViewModel userViewModel) => new AppUserDTO
        {
            UserName = userViewModel?.UserName,
            NormalizedUserName = userViewModel.UserName.ToUpper(CultureInfo.GetCultureInfo(1049))
        };
    }
}
