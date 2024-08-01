using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models
{
    public partial class SdProductCharge
    {
        public SdProductCharge()
        {
            SdProductChargesProperties = new HashSet<SdProductChargesProperty>();
        }

        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? SaleTaxId { get; set; }
        public string? BuyInvoiceNumber { get; set; }
        public DateTime? ChargeDate { get; set; }
        public int? BuyPrice { get; set; }
        public int? BuyCount { get; set; }
        public int? PercentInterest { get; set; }
        public int? PercentWages { get; set; }
        public string? Idddl { get; set; }

        public virtual SdProduct? Product { get; set; }
        public virtual BdTax? SaleTax { get; set; }
        public virtual ICollection<SdProductChargesProperty> SdProductChargesProperties { get; set; }
    }
}
