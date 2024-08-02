using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class BdState
    {
        public BdState()
        {
            BdCities = new HashSet<BdCity>();
            BdSendBoxPrices = new HashSet<BdSendBoxPrice>();
            BdSendProductsPrices = new HashSet<BdSendProductsPrice>();
        }

        public int Id { get; set; }
        public int? CountryId { get; set; }
        public string? Title { get; set; }

        public virtual BdCountry? Country { get; set; }
        public virtual ICollection<BdCity> BdCities { get; set; }
        public virtual ICollection<BdSendBoxPrice> BdSendBoxPrices { get; set; }
        public virtual ICollection<BdSendProductsPrice> BdSendProductsPrices { get; set; }
    }
}
