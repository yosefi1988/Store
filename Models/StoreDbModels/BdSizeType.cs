using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class BdSizeType
    {
        public BdSizeType()
        {
            SdProductSizes = new HashSet<SdProductSize>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<SdProductSize> SdProductSizes { get; set; }
    }
}
