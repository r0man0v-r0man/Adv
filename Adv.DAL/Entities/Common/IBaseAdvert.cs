using Adv.DAL.Entities.Images;
using System.Collections.Generic;

namespace Adv.DAL.Entities.Common
{
    public interface IBaseAdvert
    {
        int Id { get; set; }
        string AppUserId { get; set; }
        AppUser AppUser { get; set; }
        bool IsActive { get; set; }
        List<Image> Images { get; set; }
        string Address { get; set; }
    }
}
