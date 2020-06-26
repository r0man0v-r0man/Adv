using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adv.API.Models.Files;
using Adv.BLL.DTO.Adverts;
using Adv.BLL.DTO.Images;

namespace Adv.API.Models.Adverts
{
    public class FlatSaleViewModel : API.Models.Common.AuditableEntity
    {
        /// <summary>
        /// номер объявления
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// создатель объявления
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// активность объявления
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// фотографии объявления
        /// </summary>
        public List<FileModel> Images { get; set; }
        /// <summary>
        /// адрес объявления
        /// </summary>
        public AddressViewModel Address { get; set; }
        /// <summary>
        /// этаж 
        /// </summary>
        public int Floor { get; set; }
        /// <summary>
        /// всего этажей
        /// </summary>
        public int AllFloor { get; set; }
        /// <summary>
        /// количество комнат
        /// </summary>
        public byte Rooms { get; set; }
        /// <summary>
        /// Общая площадь
        /// </summary>
        public int FlatArea { get; set; }
        /// <summary>
        /// Жилая площадь
        /// </summary>
        public int FlatLiveArea { get; set; }
        /// <summary>
        /// Площадь кухни
        /// </summary>
        public int KitchenArea { get; set; }
        /// <summary>
        /// наличие балкона
        /// </summary>
        public byte Balcony { get; set; }
        /// <summary>
        /// туалет
        /// </summary>
        public byte Toilet { get; set; }
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

        /// <summary>
        /// View -> DTO
        /// </summary>
        /// <param name="view"></param>
        public static implicit operator FlatSaleDto(FlatSaleViewModel view) => new FlatSaleDto
        {
            Id = view.Id,
            UserId = view.UserId,
            IsActive = view.IsActive,
            Images = view.Images.Select(img => (ImageDto) img).ToList(),
            Address = view.Address,
            Floor = view.Floor,
            AllFloor = view.AllFloor,
            Rooms = view.Rooms,
            FlatArea = view.FlatArea,
            FlatLiveArea = view.FlatLiveArea,
            KitchenArea = view.KitchenArea,
            Balcony = view.Balcony,
            Toilet = view.Toilet,
            Price = view.Price,
            Phone = view.Phone,
            Description = view.Description
        };
        /// <summary>
        /// DTO -> View
        /// </summary>
        /// <param name="dto"></param>
        public static implicit operator FlatSaleViewModel(FlatSaleDto dto) => new FlatSaleViewModel
        {
            Id = dto.Id,
            UserId = dto.UserId,
            IsActive = dto.IsActive,
            Images = dto.Images.Select(imgDto => (FileModel) imgDto).ToList(),
            Address = dto.Address,
            Floor = dto.Floor,
            AllFloor = dto.AllFloor,
            Rooms = dto.Rooms,
            FlatArea = dto.FlatArea,
            FlatLiveArea = dto.FlatLiveArea,
            KitchenArea = dto.KitchenArea,
            Balcony = dto.Balcony,
            Toilet = dto.Toilet,
            Price = dto.Price,
            Phone = dto.Phone,
            Description = dto.Description,
            Created = dto.Created,
            LastModified = dto.LastModified
        };
    }
}
