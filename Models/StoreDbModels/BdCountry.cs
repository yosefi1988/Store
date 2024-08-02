using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class BdCountry
    {
        public BdCountry()
        {
            BdStates = new HashSet<BdState>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Logo { get; set; }

        public virtual ICollection<BdState> BdStates { get; set; }
    }
}
