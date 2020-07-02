namespace Adv.BLL.DTO.Address
{
    public class GeocoderMetaDataDto
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public string Text { get; set; }
        public string Precision { get; set; }
        public YandexAddressDto Address { get; set; }
    }
}