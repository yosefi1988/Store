using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models
{
    public partial class BdSendProductsPrice
    {
        public int Id { get; set; }
        public int? Price { get; set; }
        public int? StateId { get; set; }
        public int? ProductId { get; set; }
        public string? Title { get; set; }

        public virtual SdProduct? Product { get; set; }
        public virtual BdState? State { get; set; }
    }
}
