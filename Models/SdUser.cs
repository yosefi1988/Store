using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models
{
    public partial class SdUser
    {
        public SdUser()
        {
            ScAdmins = new HashSet<ScAdmin>();
            SdAddresses = new HashSet<SdAddress>();
            SdShoppingBaskets = new HashSet<SdShoppingBasket>();
            SdVotes = new HashSet<SdVote>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Mobile { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ScAdmin> ScAdmins { get; set; }
        public virtual ICollection<SdAddress> SdAddresses { get; set; }
        public virtual ICollection<SdShoppingBasket> SdShoppingBaskets { get; set; }
        public virtual ICollection<SdVote> SdVotes { get; set; }
    }
}
