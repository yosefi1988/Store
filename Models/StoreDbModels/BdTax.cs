using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class BdTax
    {
        public BdTax()
        {
            SdProductCharges = new HashSet<SdProductCharge>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public int? TaxPercentage { get; set; }
        public int? CountryId { get; set; }

        public virtual ICollection<SdProductCharge> SdProductCharges { get; set; }
    }
}
