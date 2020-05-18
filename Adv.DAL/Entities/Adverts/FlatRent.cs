using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL.Entities.Adverts
{
    public class FlatRent
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

    }
}
