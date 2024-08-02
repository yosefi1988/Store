using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class SdCoupon
    {
        public SdCoupon()
        {
            SdTransactions = new HashSet<SdTransaction>();
        }

        public int Id { get; set; }
        public string? Code { get; set; }
        public int? CouponPercent { get; set; }
        public int? MaxRialValue { get; set; }
        public DateTime? ExpireDate { get; set; }

        public virtual ICollection<SdTransaction> SdTransactions { get; set; }
    }
}
