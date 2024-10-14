using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class ViewUserProductSendPrice
    {
        public int? ProductId { get; set; }
        public int? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public int? StateId { get; set; }
        public string? StateTitle { get; set; }
        public string? SendTitle { get; set; }
        public int? SendPrice { get; set; }
    }
}
