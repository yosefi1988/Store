using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models
{
    public partial class BdPaymentStatusType
    {
        public BdPaymentStatusType()
        {
            SdTransactions = new HashSet<SdTransaction>();
        }

        public int Id { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<SdTransaction> SdTransactions { get; set; }
    }
}
