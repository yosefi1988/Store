using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models
{
    public partial class SdProductCategory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }

        public virtual SdCategory Category { get; set; } = null!;
        public virtual SdProduct Product { get; set; } = null!;
    }
}
