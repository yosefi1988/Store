using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models
{
    public partial class BdSendBoxPrice
    {
        public BdSendBoxPrice()
        {
            SdSendBoxes = new HashSet<SdSendBox>();
        }

        public int Id { get; set; }
        public int? Price { get; set; }
        public int? StateId { get; set; }
        public string? Title { get; set; }

        public virtual BdState? State { get; set; }
        public virtual ICollection<SdSendBox> SdSendBoxes { get; set; }
    }
}
