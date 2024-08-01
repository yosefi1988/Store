using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models
{
    public partial class BdShoppingBasketType
    {
        public BdShoppingBasketType()
        {
            SdShoppingBaskets = new HashSet<SdShoppingBasket>();
        }

        public int Id { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<SdShoppingBasket> SdShoppingBaskets { get; set; }
    }
}
