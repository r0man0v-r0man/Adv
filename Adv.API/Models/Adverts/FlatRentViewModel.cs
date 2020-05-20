using Adv.API.Models.Files;
using Adv.BLL.DTO.Adverts;
using Adv.BLL.DTO.Images;
using System.Collections.Generic;
using System.Linq;

namespace Adv.API.Models.Adverts
{
    /// <summary>
    /// View Модель объявления - квартира сдать
    /// </summary>
    public class FlatRentViewModel : API.Models.Common.AuditableEntity
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
        /// наличие балкона
        /// </summary>
        public byte Balcony { get; set; }
        /// <summary>
        /// наличие мебели
        /// </summary>
        public bool Furniture { get; set; }
        /// <summary>
        /// наличие холодильника
        /// </summary>
        public bool Refrigerator { get; set; }
        /// <summary>
        /// наличие микроволновой печи
        /// </summary>
        public bool MicrowaveOven { get; set; }
        /// <summary>
        /// наличие интернета
        /// </summary>
        public bool Internet { get; set; }
        /// <summary>
        /// наличие стиральной машины
        /// </summary>
        public bool WashingMachine { get; set; }
        /// <summary>
        /// цена
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// тип аренды
        /// </summary>
        public byte Duration { get; set; }
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
        /// <param name="flatRentViewModel"></param>
        public static implicit operator FlatRentDto(FlatRentViewModel flatRentViewModel) => new FlatRentDto
        {
            Id = flatRentViewModel.Id,
            UserId = flatRentViewModel.UserId,
            IsActive = flatRentViewModel.IsActive,
            Images = flatRentViewModel.Images.Select(fileModel => (ImageDto)fileModel).ToList(),
            Address = flatRentViewModel.Address,
            Floor = flatRentViewModel.Floor,
            AllFloor = flatRentViewModel.AllFloor,
            Rooms = flatRentViewModel.Rooms,
            Balcony = flatRentViewModel.Balcony,
            Furniture = flatRentViewModel.Furniture,
            Refrigerator = flatRentViewModel.Refrigerator,
            MicrowaveOven = flatRentViewModel.MicrowaveOven,
            Internet = flatRentViewModel.Internet,
            WashingMachine = flatRentViewModel.WashingMachine,
            Price = flatRentViewModel.Price,
            Duration = flatRentViewModel.Duration,
            Phone = flatRentViewModel.Phone,
            Description = flatRentViewModel.Description
        };
        /// <summary>
        /// DTO -> View
        /// </summary>
        /// <param name="dto"></param>
        public static implicit operator FlatRentViewModel(FlatRentDto dto) => new FlatRentViewModel
        {
            Id = dto.Id,
            UserId = dto.UserId,
            IsActive = dto.IsActive,
            Images = dto.Images.Select(imgDto => (FileModel) imgDto).ToList(),
            Address = dto.Address,
            Floor = dto.Floor,
            AllFloor = dto.AllFloor,
            Rooms = dto.Rooms,
            Balcony = dto.Balcony,
            Furniture = dto.Furniture,
            Refrigerator = dto.Refrigerator,
            MicrowaveOven = dto.MicrowaveOven,
            Internet = dto.Internet,
            WashingMachine = dto.WashingMachine,
            Price = dto.Price,
            Duration = dto.Duration,
            Phone = dto.Phone,
            Description = dto.Description
        };
    }
}
