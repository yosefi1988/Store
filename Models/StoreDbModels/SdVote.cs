using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class SdVote
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductChargePropertiesId { get; set; }
        public byte? Star { get; set; }
        public string? Comment { get; set; }

        public virtual SdProductChargesProperty ProductChargeProperties { get; set; } = null!;
        public virtual SdUser User { get; set; } = null!;
    }
}
