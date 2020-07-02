using System.Collections.Generic;

namespace Adv.API.Models.Address
{
    public class YandexAddressViewModel
    {
        public int Id { get; set; }
        public string Country_code { get; set; }
        public string Postal_code { get; set; }
        public string Formatted { get; set; }
        public IEnumerable<ComponentViewModel> Components { get; set; }
    }
}