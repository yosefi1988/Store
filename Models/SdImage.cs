using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models
{
    public partial class SdImage
    {
        public int Id { get; set; }
        public int? ProductChargePropertiesId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual SdProductChargesProperty? ProductChargeProperties { get; set; }
    }
}
