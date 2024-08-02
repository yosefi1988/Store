using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class SdShoppingBasketObject
    {
        public int Id { get; set; }
        public int ShoppingBasketId { get; set; }
        public int ProductChargePropertiesId { get; set; }
        public int? Price { get; set; }
        public int? OldPrice { get; set; }
        public int? Count { get; set; }
        public DateTime? AddDate { get; set; }

        public virtual SdProductChargesProperty ProductChargeProperties { get; set; } = null!;
        public virtual SdShoppingBasket ShoppingBasket { get; set; } = null!;
    }
}
