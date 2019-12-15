using Adv.BLL.DTO.Enums;
using Adv.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.BLL.DTO
{
    public class FlatDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public City.District District { get; set; }
    }
}
