using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class SdAddress
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; } = null!;
        public bool IsDefault { get; set; }
        public string FullName { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
        [ValidateNever]
        public virtual BdCity City { get; set; } = null!;
        [ValidateNever]
        public virtual SdUser User { get; set; } = null!;
    }
}
