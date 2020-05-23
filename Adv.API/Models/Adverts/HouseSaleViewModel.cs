using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adv.API.Models.Files;
using Adv.BLL.DTO.Adverts;
using Adv.BLL.DTO.Images;

namespace Adv.API.Models.Adverts
{
    public class HouseSaleViewModel : API.Models.Common.AuditableEntity
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
        public string Address { get; set; }
        /// <summary>
        /// Общая площадь
        /// </summary>
        public int HouseArea { get; set; }
        /// <summary>
        /// Жилая площадь
        /// </summary>
        public int HouseLiveArea { get; set; }
        /// <summary>
        /// Площадь кухни
        /// </summary>
        public int KitchenArea { get; set; }
        /// <summary>
        /// Площадь участка
        /// </summary>
        public int HousePlotArea { get; set; }
        /// <summary>
        /// отопление
        /// </summary>
        public bool Heating { get; set; }
        /// <summary>
        /// вода
        /// </summary>
        public bool Water { get; set; }
        /// <summary>
        /// газ
        /// </summary>
        public bool Gas { get; set; }
        /// <summary>
        /// канализация
        /// </summary>
        public bool Sewage { get; set; }
        /// <summary>
        /// Электричество
        /// </summary>
        public bool Electricity { get; set; }
        /// <summary>
        /// баня
        /// </summary>
        public bool Bathhouse { get; set; }
        /// <summary>
        /// гараж
        /// </summary>
        public bool Garage { get; set; }
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
        public static implicit operator HouseSaleDto(HouseSaleViewModel view) => new HouseSaleDto
        {
            Id = view.Id,
            IsActive = view.IsActive,
            UserId = view.UserId,
            Images = view.Images.Select(img => (ImageDto) img).ToList(),
            Address = view.Address,
            HouseArea = view.HouseArea,
            HouseLiveArea = view.HouseLiveArea,
            HousePlotArea = view.HousePlotArea,
            KitchenArea = view.KitchenArea,
            Heating = view.Heating,
            Water = view.Water,
            Gas = view.Gas,
            Sewage = view.Sewage,
            Electricity = view.Electricity,
            Bathhouse = view.Bathhouse,
            Garage = view.Garage,
            Price = view.Price,
            Phone = view.Phone,
            Description = view.Description
        };
        /// <summary>
        /// DTO -> View
        /// </summary>
        /// <param name="dto"></param>
        public static implicit operator HouseSaleViewModel(HouseSaleDto dto) => new HouseSaleViewModel
        {
            Id = dto.Id,
            IsActive = dto.IsActive,
            UserId = dto.UserId,
            Images = dto.Images.Select(img => (FileModel) img).ToList(),
            Address = dto.Address,
            HouseArea = dto.HouseArea,
            HouseLiveArea = dto.HouseLiveArea,
            HousePlotArea = dto.HousePlotArea,
            KitchenArea = dto.KitchenArea,
            Heating = dto.Heating,
            Water = dto.Water,
            Gas = dto.Gas,
            Sewage = dto.Sewage,
            Electricity = dto.Electricity,
            Bathhouse = dto.Bathhouse,
            Garage = dto.Garage,
            Price = dto.Price,
            Phone = dto.Phone,
            Description = dto.Description,
            Created = dto.Created,
            LastModified = dto.LastModified
        };
    }
}
