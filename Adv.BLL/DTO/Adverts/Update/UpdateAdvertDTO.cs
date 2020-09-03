using System;
using System.Collections.Generic;
using System.Text;
using Adv.DAL.Entities.Adverts.Update;

namespace Adv.BLL.DTO.Adverts.Update
{
    public class UpdateAdvertDTO
    {
        /// <summary>
        /// цена
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// телефон
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// описание
        /// </summary>
        public string Description { get; set; }

        public static implicit operator UpdateAdvert(UpdateAdvertDTO dto) => new UpdateAdvert
        {
            Phone = dto.Phone,
            Description = dto.Description,
            Price = dto.Price
        };
    }
}
