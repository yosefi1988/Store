using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class ViewSiteProductDetailsSendPrice
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? Product { get; set; }
        public int? ProductCode { get; set; }
        public string? ProductDescription { get; set; }
        public int SendId { get; set; }
        public string? Send { get; set; }
        public int? CountryId { get; set; }
        public string? Country { get; set; }
        public int? StateId { get; set; }
        public string? State { get; set; }
        public int? Price { get; set; }
    }
}
