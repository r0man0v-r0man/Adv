using System;
using System.Collections.Generic;
using System.Text;
using Adv.DAL.Entities.Images;

namespace Adv.DAL.Entities.Common
{
    public abstract class BaseAdvert : AuditableEntity, IBaseAdvert
    {
        /// <summary>
        /// уникальный номер объявления
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// создатель объявления
        /// </summary>
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        /// <summary>
        /// активность объявления
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// фотографии объявления
        /// </summary>
        public List<Image> Images { get; set; }
        /// <summary>
        /// адрес объявления
        /// </summary>
        public string Address { get; set; }
    }
}
