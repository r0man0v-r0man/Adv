namespace Adv.BLL.DTO.Address
{
    public class YandexAddressDto
    {
        public int Id { get; set; }
        public int GeoObjectId { get; set; }
        public GeoObjectDto GeoObject { get; set; }
    }
}