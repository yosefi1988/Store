using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models
{
    public partial class SdSendBox
    {
        public int Id { get; set; }
        public int? ShoppingBasketId { get; set; }
        public int? TransactionId { get; set; }
        public int? SendPriceId { get; set; }
        public string? SendTypeTitle { get; set; }
        public int? CityId { get; set; }
        public string? Address { get; set; }
        public string? FullName { get; set; }
        public string? MobileNo { get; set; }
        public DateTime? SendDate { get; set; }
        public int? SendStatusId { get; set; }
        public string? SendTrackingNo { get; set; }

        public virtual BdCity? City { get; set; }
        public virtual BdSendBoxPrice? SendPrice { get; set; }
        public virtual BdSendStatusType? SendStatus { get; set; }
        public virtual SdShoppingBasket? ShoppingBasket { get; set; }
        public virtual SdTransaction? Transaction { get; set; }
    }
}
