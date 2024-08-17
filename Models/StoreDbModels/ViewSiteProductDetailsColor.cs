using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class ViewSiteProductDetailsColor
    {
        public int Id { get; set; }
        public int ProductChargePropertiesId { get; set; }
        public int OtherProductChargePropertiesId { get; set; }
        public string? Title { get; set; }
        public string? ColorCode { get; set; }
    }
}
