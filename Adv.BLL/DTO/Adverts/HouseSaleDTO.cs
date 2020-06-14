using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Adv.BLL.DTO.Images;
using Adv.DAL.Entities.Adverts;
using Adv.DAL.Entities.Images;

namespace Adv.BLL.DTO.Adverts
{
    public class HouseSaleDto : Common.AuditableEntity
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
        public List<ImageDto> Images { get; set; }
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
        public CityDto CityDto { get; set; }

        /// <summary>
        /// DTO -> DAL
        /// </summary>
        /// <param name="dto"></param>
        public static implicit operator HouseSale(HouseSaleDto dto) => new HouseSale
        {
            Id = dto.Id,
            IsActive = dto.IsActive,
            AppUserId = dto.UserId,
            Images = dto.Images.Select(img => (Image) img).ToList(),
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
            CityId = dto.CityDto.Id
        };
        /// <summary>
        /// DAL -> DTO
        /// </summary>
        /// <param name="dal"></param>
        public static implicit operator HouseSaleDto(HouseSale dal) => new HouseSaleDto
        {
            Id = dal.Id,
            IsActive = dal.IsActive,
            UserId = dal.AppUserId,
            Images = dal.Images.Select(img => (ImageDto) img).ToList(),
            Address = dal.Address,
            HouseArea = dal.HouseArea,
            HouseLiveArea = dal.HouseLiveArea,
            HousePlotArea = dal.HousePlotArea,
            KitchenArea = dal.KitchenArea,
            Heating = dal.Heating,
            Water = dal.Water,
            Gas = dal.Gas,
            Sewage = dal.Sewage,
            Electricity = dal.Electricity,
            Bathhouse = dal.Bathhouse,
            Garage = dal.Garage,
            Price = dal.Price,
            Phone = dal.Phone,
            Description = dal.Description,
            Created = dal.Created,
            LastModified = dal.LastModified,
            CityDto = dal.City
        };
    }
}
