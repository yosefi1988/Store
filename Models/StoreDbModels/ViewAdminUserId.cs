using System;
using System.Collections.Generic;

namespace WebApplicationStore.Models.StoreDbModels
{
    public partial class ViewAdminUserId
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
