using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models
{
    public partial class SdShoppingBasket
    {
        public SdShoppingBasket()
        {
            SdSendBoxes = new HashSet<SdSendBox>();
            SdShoppingBasketObjects = new HashSet<SdShoppingBasketObject>();
            SdTransactions = new HashSet<SdTransaction>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual BdShoppingBasketType? Status { get; set; }
        public virtual SdUser? User { get; set; }
        public virtual ICollection<SdSendBox> SdSendBoxes { get; set; }
        public virtual ICollection<SdShoppingBasketObject> SdShoppingBasketObjects { get; set; }
        public virtual ICollection<SdTransaction> SdTransactions { get; set; }
    }
}
