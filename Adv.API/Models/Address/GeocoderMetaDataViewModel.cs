namespace Adv.API.Models.Address
{
    public class GeocoderMetaDataViewModel
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public string Text { get; set; }
        public string Precision { get; set; }
        public YandexAddressViewModel Address { get; set; }
    }
}