using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class ViewAdminProductChargeId
    {
        public int Id { get; set; }
        public int ProductChargeId { get; set; }
        public string? Product { get; set; }
        public int? ProductCode { get; set; }
        public string? BuyInvoiceNumber { get; set; }
        public DateTime? ChargeDate { get; set; }
        public int? BuyCount { get; set; }
    }
}
