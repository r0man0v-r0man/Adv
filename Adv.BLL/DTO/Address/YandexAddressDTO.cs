using System.Collections.Generic;

namespace Adv.BLL.DTO.Address
{
    public class YandexAddressDto
    {
        public int Id { get; set; }
        public string Country_code { get; set; }
        public string Postal_code { get; set; }
        public string Formatted { get; set; }
        public IEnumerable<ComponentDto> Components { get; set; }
    }
}