using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models
{
    public partial class SdAddress
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? CityId { get; set; }
        public string? Address { get; set; }
        public bool? IsDefault { get; set; }
        public string? FullName { get; set; }
        public string? MobileNo { get; set; }

        public virtual BdCity? City { get; set; }
        public virtual SdUser? User { get; set; }
    }
}
