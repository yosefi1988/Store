using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models
{
    public partial class SdTransaction
    {
        public SdTransaction()
        {
            SdSendBoxes = new HashSet<SdSendBox>();
        }

        public int Id { get; set; }
        public int? ShoppingBasketId { get; set; }
        public int? SumTaxAmount { get; set; }
        public int? DiscountCodeId { get; set; }
        public int? DiscountAmount { get; set; }
        public int? SendAmount { get; set; }
        public int? SumShoppingBasketPrice { get; set; }
        public int? SumShoppingBasketDiscount { get; set; }
        public int? AmountForPay { get; set; }
        public int? PaymentStatusId { get; set; }
        public string? PaymentTrackingNo { get; set; }
        public DateTime? PaymentDate { get; set; }

        public virtual SdCoupon? DiscountCode { get; set; }
        public virtual BdPaymentStatusType? PaymentStatus { get; set; }
        public virtual SdShoppingBasket? ShoppingBasket { get; set; }
        public virtual ICollection<SdSendBox> SdSendBoxes { get; set; }
    }
}
