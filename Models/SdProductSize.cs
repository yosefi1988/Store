using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models
{
    public partial class SdProductSize
    {
        public int Id { get; set; }
        public int SizeId { get; set; }
        public int ProductChargePropertiesId { get; set; }
        public string? Value { get; set; }
        public string? Description { get; set; }

        public virtual SdProductChargesProperty ProductChargeProperties { get; set; } = null!;
        public virtual BdSizeType Size { get; set; } = null!;
    }
}
