using Adv.BLL.DTO.Adverts.Update;

namespace Adv.API.Models.Adverts.UpdateModels
{
    public class UpdateAdvertViewModel
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

        public static implicit operator UpdateAdvertDTO(UpdateAdvertViewModel view) => new UpdateAdvertDTO
        {
            Description = view.Description,
            Phone = view.Phone,
            Price = view.Price
        };
    }
}
