using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class ScStoreDetail
    {
        public int Id { get; set; }
        public string? StoreName { get; set; }
        public string? Logo { get; set; }
        public string? AboutStore { get; set; }
        public string? ReturnConditions { get; set; }
        public string? Instagram { get; set; }
        public string? Telegram { get; set; }
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }
        public string? Pinterest { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? SupportNo { get; set; }
        public string? SupportHours { get; set; }
        public string? PaymentToken { get; set; }
    }
}
