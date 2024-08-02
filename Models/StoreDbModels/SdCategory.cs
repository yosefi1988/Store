using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class SdCategory
    {
        public SdCategory()
        {
            SdProductCategories = new HashSet<SdProductCategory>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public int? Code { get; set; }

        public virtual ICollection<SdProductCategory> SdProductCategories { get; set; }
    }
}
