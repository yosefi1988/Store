using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models
{
    public partial class BdSendStatusType
    {
        public BdSendStatusType()
        {
            SdSendBoxes = new HashSet<SdSendBox>();
        }

        public int Id { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<SdSendBox> SdSendBoxes { get; set; }
    }
}
