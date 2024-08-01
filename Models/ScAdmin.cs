using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models
{
    public partial class ScAdmin
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public bool? IsLocked { get; set; }
        public string? Description { get; set; }

        public virtual SdUser? User { get; set; }
    }
}
