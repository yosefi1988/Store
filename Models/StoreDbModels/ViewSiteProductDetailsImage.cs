using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class ViewSiteProductDetailsImage
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? Name { get; set; }
        public int? Code { get; set; }
        public string? ImageUrl { get; set; }
        public int? ProductChargeId { get; set; }
        public int? ProductChargePropertiesId { get; set; }
    }
}
