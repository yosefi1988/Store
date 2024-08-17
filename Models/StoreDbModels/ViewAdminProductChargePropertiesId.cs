using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class ViewAdminProductChargePropertiesId
    {
        public int Id { get; set; }
        public int ProductChargePropertiesId { get; set; }
        public string? ProductName { get; set; }
        public int? ProductCode { get; set; }
        public string? BuyInvoiceNumber { get; set; }
        public DateTime? ChargeDate { get; set; }
        public int? BuyPrice { get; set; }
        public string? Color { get; set; }
    }
}
