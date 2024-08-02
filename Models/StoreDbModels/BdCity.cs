using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class BdCity
    {
        public BdCity()
        {
            SdAddresses = new HashSet<SdAddress>();
            SdSendBoxes = new HashSet<SdSendBox>();
        }

        public int Id { get; set; }
        public int? StateId { get; set; }
        public string? Title { get; set; }

        public virtual BdState? State { get; set; }
        public virtual ICollection<SdAddress> SdAddresses { get; set; }
        public virtual ICollection<SdSendBox> SdSendBoxes { get; set; }
    }
}
