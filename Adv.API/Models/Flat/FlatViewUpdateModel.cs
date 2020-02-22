using Adv.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adv.API.Models.Flat
{
    public class FlatViewUpdateModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public static implicit operator FlatUpdateDTO(FlatViewUpdateModel updateModel)=> new FlatUpdateDTO
        {
            Description = updateModel?.Description
        };
    }
}
