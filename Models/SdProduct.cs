using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models
{
    public partial class SdProduct
    {
        public SdProduct()
        {
            BdSendProductsPrices = new HashSet<BdSendProductsPrice>();
            SdProductCategories = new HashSet<SdProductCategory>();
            SdProductCharges = new HashSet<SdProductCharge>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Code { get; set; }

        public virtual ICollection<BdSendProductsPrice> BdSendProductsPrices { get; set; }
        public virtual ICollection<SdProductCategory> SdProductCategories { get; set; }
        public virtual ICollection<SdProductCharge> SdProductCharges { get; set; }
    }
}
