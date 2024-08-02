using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class SdProductChargesProperty
    {
        public SdProductChargesProperty()
        {
            SdImages = new HashSet<SdImage>();
            SdProductSizes = new HashSet<SdProductSize>();
            SdShoppingBasketObjects = new HashSet<SdShoppingBasketObject>();
            SdVotes = new HashSet<SdVote>();
        }

        public int Id { get; set; }
        public int? ProductChargeId { get; set; }
        public int? ColorId { get; set; }
        public int? Discount { get; set; }
        public int? RemainingCount { get; set; }

        public virtual SdColor? Color { get; set; }
        public virtual SdProductCharge? ProductCharge { get; set; }
        public virtual ICollection<SdImage> SdImages { get; set; }
        public virtual ICollection<SdProductSize> SdProductSizes { get; set; }
        public virtual ICollection<SdShoppingBasketObject> SdShoppingBasketObjects { get; set; }
        public virtual ICollection<SdVote> SdVotes { get; set; }
    }
}
