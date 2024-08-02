using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class SdColor
    {
        public SdColor()
        {
            SdProductChargesProperties = new HashSet<SdProductChargesProperty>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ColorCode { get; set; }

        public virtual ICollection<SdProductChargesProperty> SdProductChargesProperties { get; set; }
    }
}
